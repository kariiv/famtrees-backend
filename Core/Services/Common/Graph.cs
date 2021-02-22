using System;
using System.Collections.Generic;

namespace FamTrees.Core.Services.Common
{
    public class Graph
    {
        public int vertices;
        public List<int>[] edge;

        public Graph(int vertices)
        {
            this.vertices = vertices;
            edge = new List<int>[vertices + 1];
            for (int i = 0; i <= vertices; i++)
            {
                edge[i] = new List<int>();
            }
        }
        public void addEdge(int a, int b)
        {
            edge[a].Add(b);
        }
        public void DFS(int node, List<int>[] adj, int[] dp, bool[] visited)
        {
            // Mark as visited 
            visited[node] = true;

            // Traverse for all its children 
            for (int i = 0; i < adj[node].Count; i++)
            {
                // If not visited 
                if (!visited[adj[node][i]])
                    DFS(adj[node][i], adj, dp, visited);

                // Store the max of the paths 
                dp[node] = Math.Max(dp[node], 1 + dp[adj[node][i]]);
            }
        }
        public void DFSPath(int node, List<int>[] adj, int[] dp, bool[] visited, List<int> path)
        {
            // Mark as visited 
            visited[node] = true;

            // Traverse for all its children 
            for (int i = 0; i < adj[node].Count; i++)
            {
                // If not visited 
                if (!visited[adj[node][i]])
                {
                    DFSPath(adj[node][i], adj, dp, visited, path);
                }

                // Store the max of the paths
                int pathValue = 1 + dp[adj[node][i]];
                if (dp[node] < pathValue)
                {
                    dp[node] = pathValue;
                    path.Add(adj[node][i]);
                }
            }
        }
        
        public int FindLongestPathLength()
        {
            return FindLongestPathLength(FindAllPathLengths());
        }
        public int FindLongestPathLength(int[] lengths)
        {
            int ans = 0;
            for (int i = 0; i <= vertices; i++)
            {
                ans = Math.Max(ans, lengths[i]);
            }
            return ans;
        }
        public int WhoHasLongestPath()
        {
            return WhoHasLongestPath(FindAllPathLengths());
        }
        public int WhoHasLongestPath(int[] lengths)
        {
            int max = 0;
            int ans = -1;
            for (int i = 0; i <= vertices; i++)
            {
                if (lengths[i] > max)
                {
                    max = lengths[i];
                    ans = i;
                }
            }
            return ans;
        }


        public int[] FindAllPathLengths()
        {
            int n = vertices;
            List<int>[] adj = edge;
            int[] dp = new int[n + 1];
            
            bool[] visited = new bool[n + 1];

            for (int i = 0; i <= n; i++)
                if (!visited[i]) 
                    DFS(i, adj, dp, visited);

            return dp;
        }
        public List<int> FindFullPath(int i)
        {
            int n = vertices;
            List<int>[] adj = edge;
            List<int> path = new List<int>();
            
            int[] dp = new int[n + 1];
            
            bool[] visited = new bool[n + 1];
            
            DFSPath(i, adj, dp, visited, path);
            return path;
        }
    }
}
