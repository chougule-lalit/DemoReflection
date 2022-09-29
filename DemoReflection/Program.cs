using DemoReflection.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DemoReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<ParameterObjectMetaData>();
            var obj = new CashOutflowBankDropdownOutputDto();

            var type = obj.GetType();

            var properties = type.GetProperties();



            var genericTypes = properties.Where(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition()
                    == typeof(List<>));

            GetListTypePropertyDetails(genericTypes);

            var classTypes = properties.Where(x => !x.PropertyType.IsGenericType
                                    && x.PropertyType.IsClass
                                    && x.PropertyType != typeof(string)
                                    && x.PropertyType != typeof(int)
                                    && x.PropertyType != typeof(double)
                                    && x.PropertyType != typeof(decimal)
                                    && !x.PropertyType.IsEnum);

            foreach (var classType in classTypes)
            {
                var classProperties = classType.PropertyType.GetProperties();

                var classGenericTypes = classProperties.Where(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition()
                    == typeof(List<>));

                GetListTypePropertyDetails(classGenericTypes);

                foreach (var classProp in classProperties)
                {
                    var isNullable = classProp.PropertyType.IsGenericType &&
                            classProp.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
                    string dataType = classProp.PropertyType.Name;
                    if (isNullable)
                    {
                        var dTypes = classProp.PropertyType.GetGenericArguments();
                        var dt = classProp.PropertyType.GetGenericTypeDefinition();
                        dataType = dTypes[0].Name;
                    }
                    Console.WriteLine($"Name : {classProp.Name}, DataType : {dataType}, IsNullable : {isNullable}");

                }
            }


        }

        private static void GetListTypePropertyDetails(IEnumerable<PropertyInfo> genericTypes)
        {
            foreach (var generic in genericTypes)
            {
                Type[] argumentTypes = generic.PropertyType.GetGenericArguments();

                foreach (var arg in argumentTypes)
                {
                    if (arg.IsClass)
                    {
                        var argProperties = arg.GetProperties();

                        foreach (var prop in argProperties)
                        {
                            var isNullable = prop.PropertyType.IsGenericType &&
                                    prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
                            string dataType = prop.PropertyType.Name;
                            if (isNullable)
                            {
                                var dTypes = prop.PropertyType.GetGenericArguments();
                                var dt = prop.PropertyType.GetGenericTypeDefinition();
                                dataType = dTypes[0].Name;
                            }
                            Console.WriteLine($"Name : {prop.Name}, DataType : {dataType}, IsNullable : {isNullable}");

                        }
                    }

                    Console.WriteLine($"{generic.Name} is List Type {arg.Name} which {(arg.IsClass ? "can be instantiated" : "cannot be instantiated")}");
                }
            }
        }

        public static void CreateFullInstance(object obj)
        {
            if (IsGenericList(obj))
            {
                Console.WriteLine("Only for Lists...");
            }
            else
            {

                PropertyInfo[] properties = obj.GetType().GetProperties();
                foreach (var property in properties)
                {
                    Type propertyType = property.PropertyType;

                    if (property.PropertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                    {
                        var typeOfListToBeCreated = propertyType.GetGenericArguments()[0];
                        if (typeOfListToBeCreated.IsClass)
                        {
                            if (property.PropertyType.Name == "List`1")
                            {
                                var listType = typeof(List<>).MakeGenericType(typeOfListToBeCreated);
                                var list = Activator.CreateInstance(listType);

                                var addMethod = listType.GetMethod("Add");
                                addMethod.Invoke(list, new object[] { Activator.CreateInstance(typeOfListToBeCreated) });

                                property.SetValue(obj, list);
                            }
                        }
                        else
                        {
                            var listType = typeof(List<>).MakeGenericType(typeOfListToBeCreated);
                            var list = Activator.CreateInstance(listType);

                            property.SetValue(obj, list);
                        }
                    }

                    if (propertyType == typeof(List<>))
                        Console.WriteLine($"{propertyType} This is list type");

                    if (propertyType is IList && propertyType.IsGenericType)
                    {
                        Console.WriteLine($"{propertyType} This is list type");
                    }


                    if (!propertyType.IsGenericType &&
                    propertyType.GetConstructor(Type.EmptyTypes) != null)
                    {
                        var val = Activator.CreateInstance(propertyType);
                        property.SetValue(obj, val);
                        CreateFullInstance(val);
                    }
                }
            }
        }

        public static bool IsGenericList(object o)
        {
            var oType = o.GetType();
            return (oType.IsGenericType && (oType.GetGenericTypeDefinition() == typeof(List<>)));
        }

        public static List<ParameterObjectMetaData> GetXmlXPathExpression(System.Xml.XmlNodeList elements)
        {
            var listXpathExpression = new List<ParameterObjectMetaData>();
            foreach (System.Xml.XmlNode item in elements)
            {
                //#text
                if (item.Name != "#text")
                {
                    var xPath = $"/{item.Name}";
                    Console.WriteLine(xPath);
                    listXpathExpression.Add(new ParameterObjectMetaData
                    {
                        Name = item.Name,
                        XPath = xPath
                    });
                }

                if (item.ChildNodes.Count > 0)
                {
                    System.Xml.XmlNodeList xmlNodeList = item.ChildNodes;
                    if (!(xmlNodeList.Count == 1 && xmlNodeList[0].Value == Guid.Empty.ToString()))
                    {
                        foreach (System.Xml.XmlNode childNode in item.ChildNodes)
                        {
                            if (childNode.Name != "#text")
                            {
                                var xPath = $"/{item.Name}/{childNode.Name}";
                                Console.WriteLine(xPath);
                                listXpathExpression.Add(new ParameterObjectMetaData
                                {
                                    Name = childNode.Name,
                                    XPath = xPath
                                });
                            }

                            if (childNode.ChildNodes.Count > 0)
                            {
                                System.Xml.XmlNodeList xmlchildNodeList = item.ChildNodes;
                                if (!(xmlchildNodeList.Count == 1 && xmlchildNodeList[0].Value == Guid.Empty.ToString()))
                                {
                                    foreach (System.Xml.XmlNode grandChildNode in childNode.ChildNodes)
                                    {
                                        if (grandChildNode.Name != "#text")
                                        {
                                            var xPath = $"/{item.Name}/{childNode.Name}/{grandChildNode.Name}";
                                            Console.WriteLine(xPath);
                                            listXpathExpression.Add(new ParameterObjectMetaData
                                            {
                                                Name = grandChildNode.Name,
                                                XPath = xPath
                                            });
                                        }

                                        if (grandChildNode.ChildNodes.Count > 0)
                                        {
                                            System.Xml.XmlNodeList xmlgrandChildNodeList = item.ChildNodes;
                                            if (!(xmlgrandChildNodeList.Count == 1 && xmlgrandChildNodeList[0].Value == Guid.Empty.ToString()))
                                            {
                                                foreach (System.Xml.XmlNode grandGrandChildNode in grandChildNode.ChildNodes)
                                                {
                                                    if (grandGrandChildNode.Name != "#text")
                                                    {
                                                        var xPath = $"/{item.Name}/{childNode.Name}/{grandChildNode.Name}/{grandGrandChildNode.Name}";
                                                        Console.WriteLine(xPath);
                                                        listXpathExpression.Add(new ParameterObjectMetaData
                                                        {
                                                            Name = grandGrandChildNode.Name,
                                                            XPath = xPath
                                                        });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return listXpathExpression;
        }

        public static object GetInstance(string strFullyQualifiedName)
        {
            Type t = Type.GetType(strFullyQualifiedName);

            if (t.FullName == "System.String")
                return null;

            return Activator.CreateInstance(t);
        }

        private static void XMLMainFunction()
        {
            var name = typeof(CashOutflowBankDropdownOutputDto).AssemblyQualifiedName;
            var obj = GetInstance(name);
            CreateFullInstance(obj);
            var doc = GetXmlFromObject(obj);
            var elements = doc.DocumentElement.ChildNodes;
            Console.WriteLine(JsonConvert.SerializeObject(GetXmlXPathExpression(elements), Formatting.Indented));
        }

        private static System.Xml.XmlDocument GetXmlFromObject(object obj)
        {
            //For XML conversion we need root node.
            //Class obj to json with root node.
            string json = JsonConvert.SerializeObject(new { root = obj }, Formatting.Indented);

            //Json to XML
            return JsonConvert.DeserializeXmlNode(json);
        }
    }
}
