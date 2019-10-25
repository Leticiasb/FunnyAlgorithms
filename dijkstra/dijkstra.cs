static public int dijkstra(int[,] adjMatrix, int source, int destiny)
 {
     int n = adjMatrix.GetLength(0);
     
     int[] distance; // From a specific start node to all other possible nodes
     int[] previous; // Store shortest-path (always related to souce node) / precedent
     bool[] perm; // Node already DONE!
     int current;
     
     distance = Enumerable.Repeat(-1, n).ToArray(); // Presume no negative distances
     previous = Enumerable.Repeat(-1, n).ToArray();
     perm = Enumerable.Repeat(false, n).ToArray();
     
     // START
     current = source;
     distance[current] = 0;
     //perm[current] = true;

     // Mix Strategy // BFS predominates over DFS  (search with BFS walk with DFS)
     while (current != destiny)
     {
         perm[current] = true;

         // Find Neighbors
         for (int i = 0; i < n; i++)
         {
             if (adjMatrix[current, i] != 0)
             {
                 // Update distance if is SHORT  (OR never updated)
                 if(distance[i]==-1 ||
                     (distance[current] + adjMatrix[current, i]) < distance[i] )
                 {
                     distance[i] = distance[current] + adjMatrix[current, i];
                     previous[i] = current;
                 }
             }
         }

         // Choose Next
         int smallest = -1;
         for (int i = 0; i < n; i++)
         {
             if (perm[i] == true || distance[i] == -1) // Skip permanents and not reached yet
                 continue;

             if(distance[i] < smallest || smallest == -1)
             {
                 smallest = distance[i];
                 current = i;
             }
         }
         if (smallest == -1)
             break; // Destiny is UNREACHABLE

     }

     return distance[destiny];
 }
