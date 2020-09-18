using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MathML
{
    [Serializable]
    [XmlRoot("Operations")]
    public class Operations
    {
        [XmlElement(typeof(Add))]
        [XmlElement(typeof(Multiply))]
        [XmlElement(typeof(Divide))]
        [XmlElement(typeof(Subtract))]
        public List<Operation> Items { get; set; }
    }

    public abstract class Operation
    {
        public string Description { get; set; }
        public Decimal Value1 { get; set; }
        public Decimal Value2 { get; set; }
        public abstract Decimal Eval();
        public abstract string OperationOperator();

        public string Username { get { return Description.ExtractUserName(); } }
        public string OperationName { get { return Description.Split(";")[1]; } }

        public override string ToString()
        {
            return $"{Username} - {OperationName} - {Value1} {OperationOperator()} {Value2} = {Eval()}";
        }
    }

    public class Add : Operation
    {       

        public override decimal Eval()
        {
            return Value1 + Value2;
        }

        public override string OperationOperator()
        {
            return "+";
        }
    }

    public class Multiply : Operation
    {
        public override decimal Eval()
        {
            return Value1 * Value2;
        }

        public override string OperationOperator()
        {
            return "*";
        }
    }

    public class Divide : Operation
    {
        public override decimal Eval()
        {
            return Value1 / Value2;
        }
        public override string OperationOperator()
        {
            return "/";
        }
    }

    public class Subtract : Operation
    {
        public override decimal Eval()
        {
            return Value1 - Value2;
        }
        public override string OperationOperator()
        {
            return "-";
        }
    }
}
