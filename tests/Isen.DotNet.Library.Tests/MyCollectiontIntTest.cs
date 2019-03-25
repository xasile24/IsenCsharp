using System;
using Xunit;
using Isen.DotNet.Library.Lists;

namespace Isen.DotNet.Library.Tests
{
    public class MyCollectionIntTest
    {
        [Fact]
        public void CountTest()
        {
            var list = new MyCollection<int>();
            Assert.True(list.Count == 0);
            list.Add(1);
            Assert.True(list.Count == 1);
            list.Add(2);
            Assert.True(list.Count == 2);
            list.Add(3);
            Assert.True(list.Count == 3);
        }
        [Fact]
        public void AddTest()
        {
            var list = new MyCollection<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var targetArray = new int[] {1, 2, 3};
            Assert.Equal(targetArray, list.Values);
        }

        [Fact]
        public void IndexTest()
        {
            var list = new MyCollection<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.True(list.Values[0] == 1);
            Assert.True(list.Values[1] == 2);
            Assert.True(list.Values[2] == 3);
        }
	    [Fact]
        public void RemoveAtTest()
        {
            var list = new MyCollection<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
	        list.Add(4);

            list.RemoveAt(0);
	        Assert.True(list.Count == 3);
            Assert.True(list[0] == 2);
            Assert.True(list[1] == 3);
            Assert.True(list[2] == 4);

            list.RemoveAt(1);
            Assert.True(list.Count == 2);
            Assert.True(list[0] == 2);
            Assert.True(list[1] == 4);

            list.RemoveAt(1);
            Assert.True(list.Count == 1);
            Assert.True(list[0] == 2);

            list.RemoveAt(0);
            Assert.True(list.Count == 0);

            try
            {
                list.RemoveAt(0);
            }
            catch(Exception e)
            {
                Assert.True(
                    e is IndexOutOfRangeException);
            }

            try
            {
                list.RemoveAt(1);
            }
            catch(Exception e)
            {
                Assert.True(
                    e is IndexOutOfRangeException);
            }

            try
            {
                list.RemoveAt(-1);
            }
            catch(Exception e)
            {
                Assert.True(
                    e is IndexOutOfRangeException);
            }
        }
    }
}