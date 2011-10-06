using System.Configuration;

namespace Freetime.Base.Business.Configuration
{
    public class DataSessionBuilderConfigurationAttributeCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        public void Add(DataSessionBuilderConfigurationAttribute element)
        {
            BaseAdd(element);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DataSessionBuilderConfigurationAttribute();
        }

        public void Remove(DataSessionBuilderConfigurationAttribute element)
        {
            BaseRemove(element.Key);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DataSessionBuilderConfigurationAttribute)element).Key;
        }
    }
}
