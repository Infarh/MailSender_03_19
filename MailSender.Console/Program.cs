using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace MailSender.ConsoleTest
{
    class Program
    {
        private const string FileName = "TestLibrarry.dll";

        static void Main(string[] args)
        {
            //Assembly asm;
            //Module module;
            //Type type;

            //FieldInfo
            //PropertyInfo
            //ConstructorInfo
            //MethodInfo
            //EventInfo

            var file_path = Path.Combine(Environment.CurrentDirectory, FileName);
            var assembly = Assembly.LoadFile(file_path);

            //foreach (var type in assembly.ExportedTypes)
            //{
            //    Console.WriteLine(type.FullName); 
            //}
            //Console.WriteLine();

            /*
             * TestLibrarry.DataPrinter
             * TestLibrarry.InternalDataSummator
             */

            var type_data_printer = assembly.GetType("TestLibrarry.DataPrinter");
            var type_data_summator = assembly.GetType("TestLibrarry.InternalDataSummator");

            var printer_ctor = type_data_printer.GetConstructor(new[] { typeof(string) });

            var printer_1 = printer_ctor.Invoke(new object[] { "Hello World1" });
            var printer_2 = printer_ctor.Invoke(new object[] { "123" });

            var print_info = type_data_printer.GetMethod("Print");

            print_info.Invoke(printer_1, new object[] { Console.Out });
            print_info.Invoke(printer_2, new object[] { Console.Out });

            var printer_data_field = type_data_printer.GetField("_Data", BindingFlags.NonPublic | BindingFlags.Instance);

            var field_value = (string)printer_data_field.GetValue(printer_1);

            printer_data_field.SetValue(printer_1, "qwe");

            print_info.Invoke(printer_1, new object[] { Console.Out });

            var summator_42 = Activator.CreateInstance(type_data_summator);
            var summator_100 = Activator.CreateInstance(type_data_summator, 100);

            var sum_info = type_data_summator.GetMethod("Sum", BindingFlags.NonPublic | BindingFlags.Instance);

            var sum_1 = (int)sum_info.Invoke(summator_42, new object[] { 25 });
            var sum_2 = (int)sum_info.Invoke(summator_100, new object[] { 25 });

            var data_property = type_data_summator.GetProperty("Data");

            data_property.SetValue(summator_42, 50);

            var property_value = (int)data_property.GetValue(summator_42);

            var data_property_get = data_property.GetMethod;
            var data_property_set = data_property.SetMethod;

            data_property_set.Invoke(summator_42, new object[] { 72 });


            //var get_delegate = (Func<int>)data_property_get.CreateDelegate(typeof(Func<int>), printer_1);

            //var value = get_delegate();

            //var print_delegate2 = (Func<int>)Delegate.CreateDelegate(typeof(Func<int>), printer_1, print_info);

            //var value2 = print_delegate2();

            //GC.Collect();

            //var binary_formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //Stream data_stream = null;
            //binary_formatter.Serialize(data_stream, printer_1);
            //printer_1 = binary_formatter.Deserialize(data_stream);

            //var xml_serializer = new System.Xml.Serialization.XmlSerializer(type_data_printer);

            using (var xml_loger = new XmlLogger("test_file.log"))
            {
                xml_loger.Log(new XElement("node", 123));  
            }

            var int_val = 42;

            object int_obj = 42;

            int_val = (int) int_val;

            Nullable<int> int_ref = int_val;
            int? int_ref2 = int_val;

            int_val = (int) int_ref;
            int_val = int_ref.Value;

            Console.ReadLine();
        }
    }

    internal class Logger : IDisposable
    {
        private readonly BinaryWriter _Writer;

        public Logger(string file)
        {
            _Writer = new BinaryWriter(new BufferedStream(new FileStream(file, FileMode.Append, FileAccess.Write), 1024));
        }

        ~Logger() // Существенно замедляет процесс сборки мусора. Нужен только при наличии неуправляемых ресурсов
        {
            Dispose(false);
        }

        public void Log(string str) => _Writer.Write(str);
        public void Log(int value) => _Writer.Write(value);
        public void Log(bool value) => _Writer.Write(value);
        public void Log(double value) => _Writer.Write(value);

        protected bool _Disposed;
        protected virtual void Dispose(bool disposing)
        {
            if(_Disposed) return;
            _Disposed = true;
            if (disposing)
            {              // Можно освобождать управляемые ресурсы
                _Writer.Dispose();
            }
            // Освобождаем только неуправляемые ресурсы
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    internal class XmlLogger : Logger
    {
        private readonly TextWriter _XmlWriter;

        public XmlLogger(string file) : base(file)
        {
            _XmlWriter = new StreamWriter($"{file}.xml");
        }

        public void Log(XElement xml)
        {
            xml.WriteTo(new XmlTextWriter(_XmlWriter));
        }

        protected override void Dispose(bool disposing)
        {
            if(_Disposed) return;
            base.Dispose(disposing);
            if (disposing)
            {
                _XmlWriter.Dispose();
            }   
        }
    }
}
