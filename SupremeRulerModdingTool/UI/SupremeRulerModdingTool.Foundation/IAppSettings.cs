namespace SupremeFiction.UI.SupremeRulerModdingTool.Foundation
{
    public interface IAppSettings
    {
        object this[string key] { get; set; }

        void Save();
    }
}
