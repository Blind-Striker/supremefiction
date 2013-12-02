﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFiction.DarkMatterFramework.Libraries.IOLibrary;
using SupremeRulerModdingTool.Foundation.Models;

namespace SupremeRulerModdingTool.Core
{
    public class UnitFileHelper
    {
        private static readonly List<string> _categories = new List<string>() {"Units", "Missiles", "Upgrades"};
        private static List<string> _classes;
        private static List<string> _subClasses; 

        private static readonly List<ItemClass> ItemClasses = new List<ItemClass>()
        {
            new ItemClass {Category = "Units",Class = "Land Unit",SubClass = "Infantry",UnitClass = 0},
            new ItemClass {Category = "Units",Class = "Land Unit",SubClass = "Recon",UnitClass = 1},
            new ItemClass {Category = "Units",Class = "Land Unit",SubClass = "Tank",UnitClass = 2},
            new ItemClass {Category = "Units",Class = "Land Unit",SubClass = "Anti-Tank",UnitClass = 3},
            new ItemClass {Category = "Units",Class = "Land Unit",SubClass = "Artillery/MLRS/Launch Vehicle/Mortar",UnitClass = 4},
            new ItemClass {Category = "Units",Class = "Land Unit",SubClass = "Air Defense",UnitClass = 5},
            new ItemClass {Category = "Units",Class = "Land Unit",SubClass = "Transport/Bridging",UnitClass = 6},

            new ItemClass {Category = "Units",Class = "Air Units",SubClass = "Helicopter",UnitClass = 7},
            new ItemClass {Category = "Units",Class = "Air Units",SubClass = "Fighter/Interceptor",UnitClass = 9},
            new ItemClass {Category = "Units",Class = "Air Units",SubClass = "Fighter/Bomber",UnitClass = 10},
            new ItemClass {Category = "Units",Class = "Air Units",SubClass = "Fighter/Multi Role",UnitClass = 11},
            new ItemClass {Category = "Units",Class = "Air Units",SubClass = "Strategic Bomber",UnitClass = 12},
            new ItemClass {Category = "Units",Class = "Air Units",SubClass = "Patrol/AWACS/Recon/Surveillance/Surveillance/ECM/Recce",UnitClass = 13},
            new ItemClass {Category = "Units",Class = "Air Units",SubClass = "Transport/Tanker",UnitClass = 14},

            new ItemClass {Category = "Units",Class = "Naval Units",SubClass = "Submarine",UnitClass = 15},
            new ItemClass {Category = "Units",Class = "Naval Units",SubClass = "Carrier",UnitClass = 16},
            new ItemClass {Category = "Units",Class = "Naval Units",SubClass = "Battleship/Cruiser/Destroyer",UnitClass = 17},
            new ItemClass {Category = "Units",Class = "Naval Units",SubClass = "Frigate/Corvette",UnitClass = 18},
            new ItemClass {Category = "Units",Class = "Naval Units",SubClass = "Patrol/Recon",UnitClass = 19},
            new ItemClass {Category = "Units",Class = "Naval Units",SubClass = "Transport/Support",UnitClass = 20},

            new ItemClass {Category = "Missiles",Class = "Missile Units",SubClass = "Missile",UnitClass = 8},

            new ItemClass {Category = "Upgrades",Class = "Facilities",SubClass = "Facility",UnitClass = 21},
        };

        private readonly List<string> _unitHeaders;
        private readonly List<string> _missileHeaders;
        private readonly List<string> _upgradeHeaders;

        private readonly Dictionary<string, IList<ItemModel>> _container;

        public UnitFileHelper(string path)
        {
            _container = new Dictionary<string, IList<ItemModel>>();

            string readFile = IoHelper.ReadFile(path);

            using (StringReader stringReader = new StringReader(readFile))
            {
                int count = 0;
                string line;
                while ((line = stringReader.ReadLine()) != null)
                {
                    if (count == 0 || count == 4)
                    {
                        count++;
                        continue;
                    }

                    if (count == 1) // Units
                    {
                        _unitHeaders = GetHeader(line);
                        count++;
                        continue;
                    }

                    if (count == 2) // Missiles
                    {
                        _missileHeaders = GetHeader(line);
                        count++;
                        continue;
                    }

                    if (count == 3) // Upgrades
                    {
                        _upgradeHeaders = GetHeader(line);
                        count++;
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

        public static IList<string> Categories
        {
            get
            {
                return _categories;
            }
        }

        public static IList<string> GetClasses(string category)
        {
            return ItemClasses.Where(@class => @class.Category == category)
                    .Select(@class => @class.Class)
                    .Distinct()
                    .ToList();
        }

        public static IList<string> GetSubClasses(string className)
        {
            return ItemClasses.Where(@class => @class.Class == className)
                    .Select(@class => @class.SubClass)
                    .Distinct()
                    .ToList();
        }

        public IList<ItemModel> GetItemModels(string category, string className, string subClassName, string searchText)
        {
            IList<ItemModel> itemModels;
               
            bool founded = _container.TryGetValue(category, out itemModels);

            if (!founded)
            {
                return new List<ItemModel>();
            }

            List<int> unitClasses = GetUnitClasses(category, className, subClassName);

            itemModels = itemModels.Where(
                    model =>
                    (unitClasses.IsNullOrEmpty() || unitClasses.Contains(int.Parse(model["Unit Class"].ToString()))) &&
                    (searchText.IsNullOrEmpty() || model["Name"].ToString().ToLowerInvariant().Contains(searchText.ToLowerInvariant()))).ToList();

            return itemModels;
        }

        private List<string> GetHeader(string headerLine)
        {
            string header = headerLine.Substring(3);

            List<string> columns = header.Split(',').ToList();

            columns[1] = columns[1].IsNullOrEmpty() ? "Name" : columns[1];

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

        private List<string> GetHeaderByCategory(string category)
        {
            if (category == "Units")
            {
                return _unitHeaders;
            }

            if (category == "Missiles")
            {
                return _missileHeaders;
            }

            if (category == "Upgrades")
            {
                return _upgradeHeaders;
            }

            // Todo: throw exception

            return null;
        }

        private void AddToContainer(string category, string[] values)
        {
            IList<ItemModel> itemModels;

            bool founded = _container.TryGetValue(category, out itemModels);

            if (!founded)
            {
                _container.Add(category, new List<ItemModel>());
            }

            List<string> headerByCategory = GetHeaderByCategory(category);

            ItemModel model = new ItemModel();

            for (int i = 0; i < headerByCategory.Count; i++)
            {
                string header = headerByCategory[i];
                string value = values[i];

                if (header.IsNullOrEmpty() || header == "-")
                {
                    header = string.Format("Column{0}", i);
                }

                object objValue;
                bool dublicateHeader = model.TryGetValue(header, out objValue);

                if (dublicateHeader)
                {
                    header = string.Format("{0}{1}", header, i);
                }

                model[header] = value;
            }


            _container[category].Add(model);
        }

        private List<int> GetUnitClasses(string category, string className, string subClassName)
        {
            return ItemClasses.Where(@class =>
                (category.IsNullOrEmpty() || @class.Category == category) &&
                (className.IsNullOrEmpty() || @class.Class == className) &&
                (subClassName.IsNullOrEmpty() || @class.SubClass == subClassName))
                .Select(@class => @class.UnitClass)
                .ToList();
        }
    }
}