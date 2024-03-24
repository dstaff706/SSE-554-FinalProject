using System;
using System.Collections.Generic;

namespace FinalProject
{
    //Using Tree Code from section 5.1
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }
        public int GetHeight()
        {
            int height = 1;
            TreeNode<T> current = this;
            while (current.Parent != null)
            {
                height++;
                current = current.Parent;
            }
            return height;
        }
    }

    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public Person() { }
        public Person(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }
    }

    public class OrgChart
    {
        private Tree<Person> company;

        public OrgChart()
        {
            InitializeCompany();
        }

        private void InitializeCompany()
        {
            company = new Tree<Person>();
            company.Root = new TreeNode<Person>()
            {
                Data = new Person(100, "Charles Babbage", "Chief Specialist"),
                Parent = null
            };
            company.Root.Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>()
                {
                    Data = new Person(1, "Ada Lovelace", "Tier 1 Specialist"),
                    Parent = company.Root
                },
                new TreeNode<Person>()
                {
                    Data = new Person(50, "William Gates", "Tier 1 Specialist"),
                    Parent = company.Root
                },
                new TreeNode<Person>()
                {
                    Data = new Person(150, "Steve Jobs", "Tier 1 Specialist"),
                    Parent = company.Root
                }
            };
            company.Root.Children[0].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>()
                {
                    Data= new Person(12, "Hideo Kojima", "Tier 2 Specialist"),
                    Parent = company.Root.Children[0]
                }
            };

            company.Root.Children[2].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>()
                {
                    Data = new Person(30, "Troy Baker", "Tier 2 Specialist"),
                    Parent = company.Root.Children[2]
                },
                new TreeNode<Person>()
                {
                    Data = new Person(5, "Nolan North", "Tier 2 Specialist"),
                    Parent = company.Root.Children[2]
                },
                new TreeNode<Person>()
                {
                    Data= new Person(11, "Jennifer Hale", "Tier 2 Specialist"),
                    Parent = company.Root.Children[2]
                }
            };
        }

        public void SearchEmployee(string employeeName)
        {
            bool found = false;
            TreeNode<Person> employeeNode = FindEmployeeNode(company.Root, employeeName, ref found);
            if (found)
            {
                TreeNode<Person> bossNode = employeeNode.Parent;
                List<TreeNode<Person>> subordinates = employeeNode.Children;

                Console.WriteLine($"Employee Name: {employeeNode.Data.Name}");

                if (bossNode != null)
                {
                    Console.WriteLine($"Boss: {bossNode.Data.Name}");
                }
                else
                {
                    Console.WriteLine($"Boss: N/A");
                }

                if (subordinates != null && subordinates.Count > 0)
                {
                    Console.WriteLine("Subordinates:");
                    foreach (var subordinate in subordinates)
                    {
                        Console.WriteLine($"- {subordinate.Data.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Subordinates: None");
                }
            }
            else
            {
                Console.WriteLine($"Employee '{employeeName}' not found.");
            }
        }

        public void SearchEmployeeByRole(string role)
        {
            List<Person> employees = new List<Person>();
            TraverseTreeByRole(company.Root, role, employees);
            if (employees.Count > 0)
            {
                Console.WriteLine($"Employees with role '{role}':");
                foreach (var employee in employees)
                {
                    Console.WriteLine($"- {employee.Name}");
                }
            }
            else
            {
                Console.WriteLine($"No employees found with role '{role}'.");
            }
        }

        private TreeNode<Person> FindEmployeeNode(TreeNode<Person> node, string employeeName, ref bool found)
        {
            if (node == null)
                return null;

            if (node.Data.Name == employeeName)
            {
                found = true;
                return node;
            }

            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    TreeNode<Person> result = FindEmployeeNode(child, employeeName, ref found);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }

        private void TraverseTreeByRole(TreeNode<Person> node, string role, List<Person> employees)
        {
            if (node == null)
                return;

            if (node.Data.Role == role)
            {
                employees.Add(node.Data);
            }

            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    TraverseTreeByRole(child, role, employees);
                }
            }
        }
    }
}
