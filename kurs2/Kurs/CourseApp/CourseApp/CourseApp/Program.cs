using Service.Helpers;
using System;
using Service.Services;
using Domain.Models;

namespace CourseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupService groupService = new GroupService();
            Helper.WriteConsole(ConsoleColor.Blue, "Select one option : ");
            Helper.WriteConsole(ConsoleColor.Yellow, "1- Create name, 2- Get group by id, 3- Update group, 4- Delete group");

            while (true)
            {
                SelectOption:  string selectOption = Console.ReadLine();

                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch(selectTrueOption)
                    {
                        case 1:

                            Helper.WriteConsole(ConsoleColor.Blue, "Add group name : ");
                            string groupName = Console.ReadLine();

                            Helper.WriteConsole(ConsoleColor.Blue, "Add group teacher name : ");
                            string groupTeacher = Console.ReadLine();

                            Helper.WriteConsole(ConsoleColor.Blue, "Add group room name : ");
                            string groupRoom = Console.ReadLine();

                            Group group = new Group
                            {
                                Name = groupName,
                                Teacher = groupTeacher,
                                Room = groupRoom

                            };


                            var result = groupService.Create(group);
                            Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {result.Id}, Group name: {group.Name}, Group Teacher name:{group.Teacher}, Group Room name: {group.Name}");







                            break;
                        case 2:
                            Helper.WriteConsole(ConsoleColor.Blue, "Add group id  : ");
                            GroupId: string groupId = Console.ReadLine();
                            int id;
                            bool isGroupId = int.TryParse(groupId, out id);

                            if (isGroupId)
                            {
                                Group group = groupService.GetById(id);
                                if (group != null);
                                {
                                    Helper.WriteConsole(ConsoleColor.Green, $"Group Id : {group.Id}, Group name: {group.Name}, Group Teacher name:{group.Teacher}, Group Room name: {group.Name}");
                                    goto GroupId;
                                }
                                else
                                {
                                    Helper.WriteConsole(ConsoleColor.Red, "Group not found");
                                    goto GroupId;
                                }
                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Select Correct id type");
                                goto GroupId;
                            }
                                                      
                            break;
                        case 3:
                            Console.WriteLine(selectTrueOption);
                            break;
                        case 4:
                            Console.WriteLine(selectTrueOption);
                            break;
                        default:
                            Helper.WriteConsole(ConsoleColor.Red, "Select Correct option number");
                            break;
                    }
                    
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select correct option:");
                    goto SelectOption;
                }
            }

        }
    }
}
