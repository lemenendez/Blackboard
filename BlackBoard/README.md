# Blackboard
An implementation of Blackboard software architecture pattern.

It is divided into two projects.
Project Blackboard contains the core.

The examples implements the Blackboard for especific set of problems to be solved.


BlackBoard
==============

Blackboard.cs
--------------

It contains information about the BlackBoard (data) and provides methods to interact with the data.
Also contains informatio about the KnowledgeWorkers.

Control.cs 
--------------
Its primary objective is decised who will be the next KnowledgeWorker to be called.

ControlData.cs
--------------
It is the wrapper for the inputs and outputs in the Blackboard.


KnowledgeWorker.cs
--------------

Samples
==============

Primes
--------------

The PrimeFinder is a KnowledgeWorker and implements its methods



