using Autofac;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Services
{
    internal class UserControlFactory : IUserControlFactory
    {
        private readonly IComponentContext _context;

        public UserControlFactory(IComponentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public T Create<T>() where T : UserControl
        {
            if (typeof(T) != typeof(UserControl))
            {
                return _context.Resolve<T>();
            }
            throw new ArgumentException($"Invalid User Control type{typeof(T)}");
        }
    }
}
