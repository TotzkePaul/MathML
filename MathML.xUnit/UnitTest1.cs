using System;
using System.IO;
using System.Xml.Serialization;
using Xunit;
using MathML;

namespace MathML.xUnit
{
    public class UnitTest1
    {
        const string XML = @"<Operations>
                            <Add>
                                <Description>Joe;SUM;TURN10</Description>
                                <Value1>40</Value1>
                                <Value2>2</Value2>
                            </Add>
                            <Multiply>
                                <Description>Sam;MULTIPLY;TURN10</Description>
                                <Value1>2</Value1>
                                <Value2>3</Value2>
                            </Multiply>
                        </Operations>
                        ";
        [Fact]
        public void ExampleXML()
        {
            using TextReader reader = new StringReader(XML);

            XmlSerializer xs = new XmlSerializer(typeof(Operations));

            Operations operations = xs.Deserialize(reader) as Operations;

            Assert.Equal("Joe - SUM - 40 + 2 = 42", operations.Items[0].ToString());
            Assert.Equal("Sam - MULTIPLY - 2 * 3 = 6", operations.Items[1].ToString());
        }

        [Fact]
        public void Adding()
        {
            Add add = new Add { Description = "", Value1 = 10, Value2=7 };

            Assert.Equal(17, add.Eval());
        }

        [Fact]
        public void Subtracting()
        {
            Subtract subtract = new Subtract { Description = "", Value1 = 10, Value2 = 7 };

            Assert.Equal(3, subtract.Eval());
        }

        [Fact]
        public void Multiplying()
        {
            Multiply add = new Multiply { Description = "", Value1 = 10, Value2 = 7 };

            Assert.Equal(70, add.Eval());
        }

        [Fact]
        public void Dividing()
        {
            Divide subtract = new Divide { Description = "", Value1 = 70, Value2 = 7 };

            Assert.Equal(10, subtract.Eval());
        }
    }
}
