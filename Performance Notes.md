CPU:

* The TypeModel for protobuf-net can be "compiled", boosting performance

Network:

* Message IDs can be reordered so that the most used have lower numbers
	* Protobuf-net uses less data to transmit smaller numbers (int8 vs int16 vs ...)