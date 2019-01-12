CPU:

* The TypeModel for protobuf-net can be "compiled", boosting performance
* Task system:
	* Task drivers can be written in either a more intelligent way
	* or they can just cache their results
	* Task completion runs really slow, consider having separate lists or an ID or something to speed that up
*Item Finder:
	*FindNearestNoItemResource() can be sped up. The nearest neighbor search will check many duplicate tiles.

Network:

* Message IDs can be reordered so that the most used have lower numbers
	* Protobuf-net uses less data to transmit smaller numbers (int8 vs int16 vs ...)