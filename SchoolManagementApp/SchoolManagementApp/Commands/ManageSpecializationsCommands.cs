using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using SchoolManagementApp.Enums;
using SchoolManagementApp.Services;
using SchoolManagementApp.ViewModels.AdminControls.ManageSpecializationVMs;
using System;
using System.Windows;

namespace SchoolManagementApp.Commands
{
    internal class ManageSpecializationsCommands
    {
        private readonly ManageSpecializationsVM manageSpecializationsVM;

        private readonly ISpecializationRepository specializationRepository;

        private AddOrEdit addOrEdit = Enums.AddOrEdit.None;

        public ManageSpecializationsCommands(ManageSpecializationsVM manageSpecializationsVM, ISpecializationRepository specializationsRepository)
        {
            this.manageSpecializationsVM = manageSpecializationsVM ?? throw new ArgumentNullException(nameof(manageSpecializationsVM));
            this.specializationRepository = specializationsRepository ?? throw new ArgumentNullException(nameof(specializationsRepository));
        }

        public void DeleteSpecializationCommand()
        {
            var result = MessageBox.Show($"Are u sure u want to delete User with Id: {manageSpecializationsVM.SelectedSpecialization.Id} ?", "Warning", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                specializationRepository.Delete(manageSpecializationsVM.SelectedSpecialization.Id);
                manageSpecializationsVM.Specializations = new System.Collections.ObjectModel.ObservableCollection<Specialization>(specializationRepository.GetAll());
                manageSpecializationsVM.SelectedSpecialization = null;
            }
        }

        public void SortEntitiesById()
        {
            if (manageSpecializationsVM.Specializations != null && manageSpecializationsVM.Specializations.Count > 0)
            {
                manageSpecializationsVM.Specializations = SortById.SortEntitiesById(manageSpecializationsVM.Specializations);
            }
        }

        public void AddOrEdit()
        {
            if (addOrEdit == Enums.AddOrEdit.Add)
            {
                AddSpecialization();
            }
            else if (addOrEdit == Enums.AddOrEdit.Edit)
            {
                EditSpecialization();
            }
        }

        public void AddSpecialization()
        {
            var spec = specializationRepository.GetByName(manageSpecializationsVM.NewSpecialization);

            if (spec != null)
            {
                MessageBox.Show("Specialization already exists!", "Error");
                return;
            }
            specializationRepository.Add(new Specialization { Name = manageSpecializationsVM.NewSpecialization });
            manageSpecializationsVM.Specializations = new System.Collections.ObjectModel.ObservableCollection<Specialization>(specializationRepository.GetAll());
        }

        public void EditSpecialization()
        {
            var spec = specializationRepository.GetById(manageSpecializationsVM.SelectedSpecialization.Id);
            if (spec == null)
            {
                MessageBox.Show("Specialization invalid", "Error");
            }

            manageSpecializationsVM.SelectedSpecialization.Name = manageSpecializationsVM.NewSpecialization;
            specializationRepository.Update(manageSpecializationsVM.SelectedSpecialization);

            manageSpecializationsVM.Specializations = new System.Collections.ObjectModel.ObservableCollection<Specialization>(specializationRepository.GetAll());
        }

        public void AddView()
        {
            addOrEdit = Enums.AddOrEdit.Add;
            manageSpecializationsVM.ButtonContent = "Add";
            manageSpecializationsVM.AddOrEditWindow = "Add Specialization";
            manageSpecializationsVM.NewSpecialization = string.Empty;
        }

        public void EditView()
        {
            addOrEdit = Enums.AddOrEdit.Edit;
            manageSpecializationsVM.ButtonContent = "Edit";
            manageSpecializationsVM.AddOrEditWindow = $"Edit Specialization with Id:{manageSpecializationsVM.SelectedSpecialization.Id}";
            manageSpecializationsVM.NewSpecialization = manageSpecializationsVM.SelectedSpecialization.Name;
        }
    }
}
