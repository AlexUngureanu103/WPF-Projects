using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.Services
{
    internal class GetParentOrRootTDL
    {
        public static ToDoList GetParentOfSelectedTDL(ObservableCollection<ToDoList> RootTDLLists, ToDoList selectedTDL)
        {
            //check the roots
            foreach (var tdl in RootTDLLists)
            {
                if (tdl.Name == selectedTDL.Name)
                {
                    return tdl;
                }
            }

            ToDoList parent;
            //check the branches 
            foreach (var tdl in RootTDLLists)
            {
                parent = FindParentToDoList(selectedTDL.Name, tdl);
                if(parent != null)
                {
                    return parent;
                }
            }
            return null;
        }

        private static ToDoList FindParentToDoList(string selectedTDLName, ToDoList current)
        {
            foreach (ToDoList list in current.toDoLists)
            {
                if (list.Name == selectedTDLName)
                {
                    return current;
                }
                else
                {
                    ToDoList parent = FindParentToDoList(selectedTDLName, list);
                    if (parent != null)
                    {
                        return parent;
                    }
                }
            }
            return null;
        }

        //private static bool CheckIfCurrentTDLIsTheParent(ToDoList parentTDL, ToDoList selectedTDL)
        //{
        //    foreach (var child in parentTDL.toDoLists)
        //    {
        //        if (child.Name == selectedTDL.Name)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
