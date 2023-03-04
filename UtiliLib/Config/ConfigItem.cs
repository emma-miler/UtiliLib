using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utili.Config
{
    [AttributeUsage(AttributeTargets.Property)]
    public partial class ConfigItem : Attribute 
    {
        public virtual string SerializeValue(object value)
        {
            return value.ToString();
        }
        public virtual object DeserializeValue(string value, Type type)
        {
            return Convert.ChangeType(value, type);
        }
    }
    public partial class EncryptedConfigItem : ConfigItem {
        public override string SerializeValue(object value)
        {
            return CryptoHelper.Encrypt(value.ToString());
        }
        public override object DeserializeValue(string value, Type type)
        {
            return Convert.ChangeType(CryptoHelper.Decrypt(value), type);
        }
    }
}
