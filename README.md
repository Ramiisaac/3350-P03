# CSC 3350 Project 03 - Multithreading 

**Overview**

Implement a program that creates a thread. The thread should perform an operating system API call to open a text file, read the content of the file, and output the content to the console. The main thread should wait for the spawned thread to complete. The implementation can target Windows, MAC OS, or a Linux-based distribution.

**Program Operation**

This program performs the following operations:

1. Initiate a Parent (which waits for child thread to complete)
2. Initiate a Child thread using System.Threading.Tasks
3. Child thread opens and reads text file to console using a system API
4. Child thread completes
5. Parent thread completes
6. Catche exceptions and throw err if needed
