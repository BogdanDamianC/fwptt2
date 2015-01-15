using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace fwptt.TestProject.Project.Interfaces
{
    public class ExtendableDataJSONConverter : Util.JsonCreationConverter<ExtendableData>
    {
        protected override ExtendableData Create(Type objectType, JObject jObject)
        {
            Type dataTypeToCreate;
            if (!TestProjectHost.Current.ExpandableData.TryGetValue(jObject.Value<string>("UniqueName"), out dataTypeToCreate))
                throw new ApplicationException(jObject.Value<string>("UniqueName") + " data type is not defined inside the application or it's plugins - you probably need to add the extra plugins");

            return (ExtendableData)Activator.CreateInstance(dataTypeToCreate);

        }
    }
    /// <summary>
    /// this abstract class is used for identifying all the data classes used by the plugins
    /// </summary>
    [JsonConverter(typeof(ExtendableDataJSONConverter))]
    public abstract class ExtendableData
    {
        public abstract string UniqueName { get; }
    }

    public enum ExpandableComponentType { TimeLineConfiguration, PluginConfiguration, Plugin };
    public class ExpandableSettingsAttribute : Attribute
    {
        public ExpandableSettingsAttribute(string uniqueName, string DisplayName, ExpandableComponentType type)
        {
            this.UniqueName = uniqueName;
            this.DisplayName = DisplayName;
            this.ComponentType = type;
        }
        public string UniqueName {get; set;}
        public string DisplayName { get; set; }
        public ExpandableComponentType ComponentType { get; set; }

        public ExpandableSetting GetSetting(Type PluginType)
        {
            return new ExpandableSetting
            {
                UniqueName = this.UniqueName,
                DisplayName = this.DisplayName,
                ComponentType = this.ComponentType,
                PluginType = PluginType
            };
        }
    }

    public class ExpandableSetting
    {
        public string UniqueName { get; internal set; }
        public string DisplayName { get; internal set; }
        public ExpandableComponentType ComponentType { get; internal set; }
        public Type PluginType { get; internal set; }
    }
 
}
