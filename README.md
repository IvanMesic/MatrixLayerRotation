This is my solution for a counter clockwise matrix rotation problem presented in the Raiffeissen Agi interview proccess.

This algorithm processes a matrix by peeling it into concentric rings.

Instead of physically shifting elements one by one, it mathematically maps the origin of each element to its new target destination.

Time complexity of the algorithm is O(rows*columns) - Every element in the matrix is visited and mapped only once.

Space complexity of the algorithm is O(rows*columns) - Requires a secondary 2D array to construc the final rotated state. 

The algorithm first validates that the matrix dimensions are valid (2 isBiggerOrEqualTo rows, columns isSmallerOrEqualTo 300), the smallest dimension is even and the rotation factor is within bounds.

The algorithm then calculates concentric ring layers using Math.min(rows, columns) / 2.

Then for each layer the GetLayerCoordinates function traces the top, right, bottom and left boundaries to calculate a sequential, 1D track of coordinates.

After that for each target coordinate the exact source of the elements is calculated using ((currentIndex + rotation) % track_length) to achieve a counter-clockwise rotation.

Finally, the values are read from the original matrix and placed directly into their target coordinates in the new 2D array which is printed.

Usage:

The program reads directly from the standard input console.

Expected input on the first line is 3 space seperated integers: m(rows) n(columns) r(rotation factor).
Next m lines should contain n space seperate integers representing the rows of the matrix.

Example input:

4 4 2

1 2 3 4

5 6 7 8

9 10 11 12

13 14 15 16

Example output:

3 4 8 12

2 11 10 16

1 7 6 15

5 9 13 14
