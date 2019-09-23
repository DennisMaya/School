"""
EE 381 fall 2019
Project 1
Name: Dennis Maya
I.D.: 015850768
Start Date: 8-26-2019
End Date:9-4-19
This program calculates the measures of central tendency of inputted data.
"""

from collections import Counter

def findMean(L):
    mean = sum(L) / len(L)
    print("The mean is: ", mean)

def findMedian(L):
    L.sort() #sorts the list
    median = 0
    if len(L) % 2 == 0: #checks if the length of the list is even
        #gets the average of the 2 middle numbers
        median = L[(int(len(L)/2))] + L[(int(len(L)/2))+1] 
        median = median / 2
        median -= 1
    else:
        median = L[int(len(L)/2)]
    print("The median is: ", median)

def findMode(L):
    c = Counter(L)
    freq = c.most_common()
    max_occur = freq[0][1]
    if max_occur != 1:
        modes = []
        for m in freq:
            if m[1] == max_occur:
                modes.append(m[0])
        print("The mode(s) are: ", modes)
    else:
        print ("There are no modes")        

def main():
    #inputting data
    L = [] #List for the data
    v = 1 #Boolean varianle set to high logic
    print("You will be asked to input nonnegative integer data.")
    print("When you're done input the letter 's'.")

    while(v == 1):
        try:
            l = int(input("Enter a nonnegative integer.")) #prompt
            L.append(l)
        except ValueError:
            print("Input has been halted")
            print("\n")
            v = 0 #set boolean to low logic

    print("You inputted this list of numbers. ", L)
    findMean(L)
    findMedian(L)
    findMode(L)
    
            

main()

