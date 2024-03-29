﻿using SchoolManagementApp.Domain.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface ITeacherService : ICollectionService<Teacher>
    {
        ObservableCollection<Teacher> TeacherList { get; set; }

        string errorMessage { get; set; }

        Teacher GetTeacherById(int id);
    }
}
