using SchoolManagementApp.Domain.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchoolManagementApp.Services
{
    internal static class SortById
    {
        private static bool isSortedById = false;

        public static ObservableCollection<T> SortEntitiesById<T>(ObservableCollection<T> entities) where T : BaseEntity
        {
            if (isSortedById)
            {
                isSortedById = false;
                return new ObservableCollection<T>(entities.OrderBy(entity => entity.Id).ToList());
            }
            else
            {
                isSortedById = true;
                return new ObservableCollection<T>(entities.OrderByDescending(entity => entity.Id).ToList());
            }
        }
    }
}
