using System.Collections.Generic;
using System.Linq;
using Xunit;
using FamTrees.Core.Services.Common;
using Xunit.Abstractions;

namespace FamTrees.UnitTests.Core.Services
{
    public class MostPredecessorsTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private Graph small;
        private Graph smallInverted;
        private Graph verySmall;
        private Graph small2;
        private Graph big;

        public MostPredecessorsTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            big = new(13);
            big.addEdge(2, 1);
            big.addEdge(6, 9);
            big.addEdge(3, 2);
            big.addEdge(3, 6);
            big.addEdge(5, 7);
            big.addEdge(5, 8);
            big.addEdge(4, 3);
            big.addEdge(4, 5);
            big.addEdge(3, 2);
            big.addEdge(3, 6);
            big.addEdge(6, 10);
            big.addEdge(10, 11);
            big.addEdge(10, 12);
            big.addEdge(12, 13);

            small = new(3);
            small.addEdge(2, 1);
            small.addEdge(0, 1);
            small.addEdge(3, 0);

            smallInverted = new(3);
            smallInverted.addEdge(2, 1);
            smallInverted.addEdge(0, 3);
            smallInverted.addEdge(3, 1);

            small2 = new(6);
            small2.addEdge(2, 1);
            small2.addEdge(3, 1);
            small2.addEdge(4, 2);
            small2.addEdge(2, 5);
            small2.addEdge(6, 4);

            verySmall = new(3);
            verySmall.addEdge(2, 1);
        }

        [Fact]
        public void Graph1()
        {
            Graph graph = big;
            int[] actual1 = graph.FindAllPathLengths();

            int actual2 = graph.FindLongestPathLength();
            int actual3 = graph.FindLongestPathLength(actual1);
            string expected2 = "5";

            int actual4 = graph.WhoHasLongestPath();
            int actual5 = graph.WhoHasLongestPath(actual1);
            string expected4 = "4";

            List<int> actual6 = graph.FindFullPath(actual4);

            string actual6String = string.Join("; ", actual6.Select(x => x.ToString()).ToArray());
            _testOutputHelper.WriteLine(actual6String);

            // Assert.Equal("", string.Join(", ", actual1));
            Assert.Equal(expected2, actual2.ToString());
            Assert.Equal(expected2, actual3.ToString());
            Assert.Equal(actual2.ToString(), actual3.ToString());
            Assert.Equal(expected4, actual4.ToString());
            Assert.Equal(expected4, actual4.ToString());
            Assert.Equal(actual4.ToString(), actual5.ToString());
        }
        [Fact]
        public void Graph2()
        {
            Graph graph = small;
            int[] actual1 = graph.FindAllPathLengths();

            int actual2 = graph.FindLongestPathLength();
            int actual3 = graph.FindLongestPathLength(actual1);
            string expected2 = "2";

            int actual4 = graph.WhoHasLongestPath();
            int actual5 = graph.WhoHasLongestPath(actual1);
            string expected4 = "3";

            List<int> actual6 = graph.FindFullPath(actual4);

            string actual6String = string.Join("; ", actual6.Select(x => x.ToString()).ToArray());
            _testOutputHelper.WriteLine(actual6String);

            // Assert.Equal("", string.Join(", ", actual1));
            Assert.Equal(expected2, actual2.ToString());
            Assert.Equal(expected2, actual3.ToString());
            Assert.Equal(actual2.ToString(), actual3.ToString());
            Assert.Equal(expected4, actual4.ToString());
            Assert.Equal(expected4, actual4.ToString());
            Assert.Equal(actual4.ToString(), actual5.ToString());
        }

        [Fact]
        public void Graph3()
        {
            Graph graph = smallInverted;
            int[] actual1 = graph.FindAllPathLengths();

            int actual2 = graph.FindLongestPathLength();
            int actual3 = graph.FindLongestPathLength(actual1);
            string expected2 = "2";

            int actual4 = graph.WhoHasLongestPath();
            int actual5 = graph.WhoHasLongestPath(actual1);
            string expected4 = "0";

            List<int> actual6 = graph.FindFullPath(actual4);

            string actual6String = string.Join("; ", actual6.Select(x => x.ToString()).ToArray());
            _testOutputHelper.WriteLine(actual6String);

            // Assert.Equal("", string.Join(", ", actual1));
            Assert.Equal(expected2, actual2.ToString());
            Assert.Equal(expected2, actual3.ToString());
            Assert.Equal(actual2.ToString(), actual3.ToString());
            Assert.Equal(expected4, actual4.ToString());
            Assert.Equal(expected4, actual4.ToString());
            Assert.Equal(actual4.ToString(), actual5.ToString());
        }
        [Fact]
        public void Graph4()
        {
            Graph graph = small2;
            int[] actual1 = graph.FindAllPathLengths();

            int actual2 = graph.FindLongestPathLength();
            int actual3 = graph.FindLongestPathLength(actual1);
            string expected2 = "3";

            int actual4 = graph.WhoHasLongestPath();
            int actual5 = graph.WhoHasLongestPath(actual1);
            string expected4 = "6";

            List<int> actual6 = graph.FindFullPath(actual4);

            string actual6String = string.Join("; ", actual6.Select(x => x.ToString()).ToArray());
            _testOutputHelper.WriteLine(actual6String);

            // Assert.Equal("", string.Join(", ", actual1));
            Assert.Equal(expected2, actual2.ToString());
            Assert.Equal(expected2, actual3.ToString());
            Assert.Equal(actual2.ToString(), actual3.ToString());
            Assert.Equal(expected4, actual4.ToString());
            Assert.Equal(expected4, actual4.ToString());
            Assert.Equal(actual4.ToString(), actual5.ToString());
        }
        
        [Fact]
        public void Graph5()
        {
            Graph graph = verySmall;
            int[] actual1 = graph.FindAllPathLengths();

            int actual2 = graph.FindLongestPathLength();
            int actual3 = graph.FindLongestPathLength(actual1);
            string expected2 = "1";

            int actual4 = graph.WhoHasLongestPath();
            int actual5 = graph.WhoHasLongestPath(actual1);
            string expected4 = "2";

            List<int> actual6 = graph.FindFullPath(actual4);

            string actual6String = string.Join("; ", actual6.Select(x => x.ToString()).ToArray());
            _testOutputHelper.WriteLine(actual6String);

            // Assert.Equal("", string.Join(", ", actual1));
            Assert.Equal(expected2, actual2.ToString());
            Assert.Equal(expected2, actual3.ToString());
            Assert.Equal(actual2.ToString(), actual3.ToString());
            Assert.Equal(expected4, actual4.ToString());
            Assert.Equal(expected4, actual4.ToString());
            Assert.Equal(actual4.ToString(), actual5.ToString());
        }
    }
}