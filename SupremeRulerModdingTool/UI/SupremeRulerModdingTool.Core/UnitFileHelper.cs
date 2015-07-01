using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CodeFiction.DarkMatterFramework.Libraries.IOLibrary;
using SupremeFiction.UI.SupremeRulerModdingTool.Foundation.Models;

namespace SupremeFiction.UI.SupremeRulerModdingTool.Core
{
    public class UnitFileHelper
    {
        private readonly bool _sr5;
        private static readonly List<string> CategoryList = new List<string> { "Units", "Missiles", "Upgrades" };

        private static readonly List<ItemClass> ItemClasses = new List<ItemClass>
        {
            new ItemClass { Category = "Units", Class = "Land Unit", SubClass = "Infantry", UnitClass = 0 },
            new ItemClass { Category = "Units", Class = "Land Unit", SubClass = "Recon", UnitClass = 1 },
            new ItemClass { Category = "Units", Class = "Land Unit", SubClass = "Tank", UnitClass = 2 },
            new ItemClass { Category = "Units", Class = "Land Unit", SubClass = "Anti-Tank", UnitClass = 3 },
            new ItemClass { Category = "Units", Class = "Land Unit", SubClass = "Artillery/MLRS/Launch Vehicle/Mortar", UnitClass = 4 },
            new ItemClass { Category = "Units", Class = "Land Unit", SubClass = "Air Defense", UnitClass = 5 },
            new ItemClass { Category = "Units", Class = "Land Unit", SubClass = "Transport/Bridging", UnitClass = 6 },
                            
            new ItemClass { Category = "Units", Class = "Air Units", SubClass = "Helicopter", UnitClass = 7 },
            new ItemClass { Category = "Units", Class = "Air Units", SubClass = "Fighter/Interceptor", UnitClass = 9 },
            new ItemClass { Category = "Units", Class = "Air Units", SubClass = "Fighter/Bomber", UnitClass = 10 },
            new ItemClass { Category = "Units", Class = "Air Units", SubClass = "Fighter/Multi Role", UnitClass = 11 },
            new ItemClass { Category = "Units", Class = "Air Units", SubClass = "Strategic Bomber", UnitClass = 12 },
            new ItemClass { Category = "Units", Class = "Air Units", SubClass = "Patrol/AWACS/Recon/Surveillance/Surveillance/ECM/Recce", UnitClass = 13 },
            new ItemClass { Category = "Units", Class = "Air Units", SubClass = "Transport/Tanker", UnitClass = 14 },
                            
            new ItemClass { Category = "Units", Class = "Naval Units", SubClass = "Submarine", UnitClass = 15 },
            new ItemClass { Category = "Units", Class = "Naval Units", SubClass = "Carrier", UnitClass = 16 },
            new ItemClass { Category = "Units", Class = "Naval Units", SubClass = "Battleship/Cruiser/Destroyer", UnitClass = 17 },
            new ItemClass { Category = "Units", Class = "Naval Units", SubClass = "Frigate/Corvette", UnitClass = 18 },
            new ItemClass { Category = "Units", Class = "Naval Units", SubClass = "Patrol/Recon", UnitClass = 19 },
            new ItemClass { Category = "Units", Class = "Naval Units", SubClass = "Transport/Support", UnitClass = 20 },
                            
            new ItemClass { Category = "Missiles", Class = "Missile Units", SubClass = "Missile", UnitClass = 8 },
                            
            new ItemClass { Category = "Upgrades", Class = "Facilities", SubClass = "Facility", UnitClass = 21 },
        };

        private readonly Dictionary<string, IList<ItemModel>> _container;

        private List<string> _unitColumns;
        private List<string> _missileColumns;
        private List<string> _upgradeColumns;

        public UnitFileHelper(bool sr5)
        {
            _sr5 = sr5;
            _container = new Dictionary<string, IList<ItemModel>>();
            InitColumns(sr5);
        }

        public UnitFileHelper(bool sr5, string path)
            : this(sr5)
        {
            Init(path);
        }

        public static IEnumerable<string> Categories
        {
            get
            {
                return CategoryList;
            }
        }

        public Dictionary<string, IList<ItemModel>> Container
        {
            get
            {
                return _container;
            }
        }

        public static IEnumerable<string> GetClasses(string category)
        {
            return ItemClasses.Where(@class => @class.Category == category)
                    .Select(@class => @class.Class)
                    .Distinct()
                    .ToList();
        }

        public static IEnumerable<string> GetSubClasses(string className)
        {
            return ItemClasses.Where(@class => @class.Class == className)
                    .Select(@class => @class.SubClass)
                    .Distinct()
                    .ToList();
        }

        public void InitColumns(bool sr5)
        {
            if (!sr5)
            {
                _unitColumns = GetHeaderLine(Columns.UNITS);
                _missileColumns = GetHeaderLine(Columns.Missiles);
                _upgradeColumns = GetHeaderLine(Columns.upgrades);
            }
            else
            {
                _unitColumns = GetHeaderLine(Columns.SR5ID);
                _missileColumns = GetHeaderLine(Columns.SR5ID);
                _upgradeColumns = GetHeaderLine(Columns.SR5ID);
            }

            //string readFile = ReadFile(defaultUnitFilePath);

            //using (var stringReader = new StringReader(readFile))
            //{
            //    int count = 0;
            //    string line;
            //    while ((line = stringReader.ReadLine()) != null)
            //    {
            //        if (count > 4)
            //        {
            //            break;
            //        }

            //        if (count == 0 || count == 4)
            //        {
            //            count++;
            //            continue;
            //        }

            //        // Units
            //        if (count == 1)
            //        {
            //            _unitColumns = GetHeaderLine(line);
            //            count++;
            //            continue;
            //        }

            //        // Missiles
            //        if (count == 2)
            //        {
            //            _missileColumns = GetHeaderLine(line);
            //            count++;
            //            continue;
            //        }

            //        // Upgrades
            //        if (count == 3)
            //        {
            //            _upgradeColumns = GetHeaderLine(line);
            //            count++;
            //        }
            //    }
            //}
        }

        public void Init(string path)
        {
            string readFile = ReadFile(path);

            using (var stringReader = new StringReader(readFile))
            {
                //int count = 0;
                string line;
                while ((line = stringReader.ReadLine()) != null)
                {
                    if (line.IsNullOrEmpty())
                    {
                        //count++;
                        continue;                        
                    }

                    if (line.Contains("RAWPROD"))
                    {
                        //count++;
                        break;
                    }

                    int integer;
                    bool isInteger = int.TryParse(line[0].ToString(CultureInfo.InvariantCulture), out integer);

                    //if (count <= 4)
                    //{
                    //    count++;
                    //    continue;
                    //}

                    if (!isInteger)
                    {
                        // count++;
                        continue;
                    }

                    string[] values = line.Split(',');

                    string strUnitClass = values[2];
                    int unitClass;

                    bool parsed = int.TryParse(strUnitClass, out unitClass);

                    if (!parsed)
                    {
                        continue;
                    }

                    string categoryByUnitClass = GetCategoryByUnitClass(unitClass);

                    AddToContainer(categoryByUnitClass, values);
                }
            }
        }

        public IEnumerable<ItemModel> GetItemModels(string category, string className, string subClassName, string searchText)
        {
            IList<ItemModel> itemModels;

            const string SrUnitClassColumnName = "Unit Class";
            const string SrNameColumnName = "Name";

            const string Sr5UnitClassColumnName = "ClassNum";
            const string Sr5NameColumnName = "ModelCode+EquipName";

            bool founded = _container.TryGetValue(category, out itemModels);

            if (!founded)
            {
                return new List<ItemModel>();
            }

            List<int> unitClasses = GetUnitClasses(category, className, subClassName);

            itemModels = itemModels.Where(
                    model =>
                    (unitClasses.IsNullOrEmpty() || unitClasses.Contains(int.Parse(model[_sr5 ? Sr5UnitClassColumnName : SrUnitClassColumnName].ToString()))) &&
                    (searchText.IsNullOrEmpty() || model[_sr5 ? Sr5NameColumnName : SrNameColumnName].ToString().ToLowerInvariant().Contains(searchText.ToLowerInvariant()))).ToList();

            return itemModels;
        }

        public List<string> GetColumnsByCategory(string category)
        {
            if (category == "Units")
            {
                return _unitColumns;
            }

            if (category == "Missiles")
            {
                return _missileColumns;
            }

            if (category == "Upgrades")
            {
                return _upgradeColumns;
            }

            // Todo: throw exception

            return null;
        }

        public List<int> GetUnitClasses(string category, string className, string subClassName)
        {
            return ItemClasses.Where(@class =>
                (category.IsNullOrEmpty() || @class.Category == category) &&
                (className.IsNullOrEmpty() || @class.Class == className) &&
                (subClassName.IsNullOrEmpty() || @class.SubClass == subClassName))
                .Select(@class => @class.UnitClass)
                .ToList();
        }

        private static string ReadFile(string filePath)
        {
            // TODO : add to core library
            using (var streamReader = new StreamReader(filePath, Encoding.GetEncoding("iso-8859-1")))
            {
                return streamReader.ReadToEnd();
            }
        }

        private List<string> GetHeaderLine(string headerLine)
        {
            var columns = new List<string>();

            string header = headerLine.Substring(3);
            List<string> tempColumns = header.Split(',').ToList();
            tempColumns[1] = tempColumns[1].IsNullOrEmpty() ? "Name" : tempColumns[1];

            for (int i = 0; i < tempColumns.Count; i++)
            {
                string columnName = tempColumns[i];

                if (columnName.IsNullOrEmpty() || header == "-")
                {
                    columnName = string.Format("Column{0}", i);
                }

                if (columns.Contains(columnName))
                {
                    columnName = string.Format("{0}{1}", columnName, i);
                }

                columns.Add(columnName);
            }

            return columns;
        }

        private string GetCategoryByUnitClass(int unitClass)
        {
            // Todo : Cache
            string category = ItemClasses.Where(@class => @class.UnitClass == unitClass)
                    .Select(@class => @class.Category)
                    .Distinct()
                    .FirstOrDefault();

            if (category.IsNullOrEmpty())
            {
                // throw exception
            }

            return category;
        }

        private void AddToContainer(string category, string[] values)
        {
            IList<ItemModel> itemModels;

            bool founded = _container.TryGetValue(category, out itemModels);

            if (!founded)
            {
                _container.Add(category, new List<ItemModel>());
            }

            List<string> columns = GetColumnsByCategory(category);

            // TODO : Last minute change. Adding support for Supreme Ruler 2020 file. Ugly code will be removed
            if (columns.Count == 134 && values.Length == 133) // Supreme Ruler 2020
            {
                columns.RemoveAt(columns.Count - 1);
            }

            var model = new ItemModel();

            for (int i = 0; i < columns.Count; i++)
            {
                string header = columns[i].Trim();
                string value = values[i].Trim();

                model[header] = value;
            }

            _container[category].Add(model);
        }
    }
}
