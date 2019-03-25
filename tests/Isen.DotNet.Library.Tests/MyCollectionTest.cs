using System;
using Xunit;
using Isen.DotNet.Library.Lists;

namespace Isen.DotNet.Library.Tests
{
    public class MyCollectionTest
    {
        [Fact]
        public void CountTest()
        {
            var list = new MyCollection();
            Assert.True(list.Count == 0);
            list.Add("A");
            Assert.True(list.Count == 1);
            list.Add("B");
            Assert.True(list.Count == 2);
            list.Add("C");
            Assert.True(list.Count == 3);
        }
        [Fact]
        public void AddTest()
        {
            var list = new MyCollection();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            var targetArray = new string[] {"A", "B", "C"};
            Assert.Equal(targetArray, list.Values);
        }

        [Fact]
        public void IndexTest()
        {
            var list = new MyCollection();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            Assert.True(list.Values[0] == "A");
            Assert.True(list.Values[1] == "B");
            Assert.True(list.Values[2] == "C");
        }
	    [Fact]
        public void RemoveAtTest()
        {
            var list = new MyCollection();
            list.Add("A");
            list.Add("B");
            list.Add("C");
	        list.Add("D");

            list.RemoveAt(0);
	        Assert.True(list.Count == 3);
            Assert.True(list[0] == "B");
            Assert.True(list[1] == "C");
            Assert.True(list[2] == "D");

            list.RemoveAt(1);
            Assert.True(list.Count == 2);
            Assert.True(list[0] == "B");
            Assert.True(list[1] == "D");

            list.RemoveAt(1);
            Assert.True(list.Count == 1);
            Assert.True(list[0] == "B");

            list.RemoveAt(0);
            Assert.True(list.Count == 0);
        }
    }
}