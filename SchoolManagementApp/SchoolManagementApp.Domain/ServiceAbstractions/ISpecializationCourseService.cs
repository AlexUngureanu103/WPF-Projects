﻿using SchoolManagementApp.Domain.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface ISpecializationCourseService : ICollectionService<SpecializationCourse>
    {
        ObservableCollection<SpecializationCourse> SpecializationCourseList { get; set; }

        string errorMessage { get; set; }

        bool EntityAlreadyExists(SpecializationCourse specializationCourse);
    }
}
