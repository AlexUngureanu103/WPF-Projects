using System;
using System.Windows.Markup;

namespace To_Do_List_Management_App.Services
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType { get; set; }

        public EnumBindingSourceExtension(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("enum Type is not and Enum");
            }
            EnumType = enumType ?? throw new ArgumentNullException(nameof(enumType));
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
