"""
EE 382 fall 2019
Project 2
I.D. #: 015850768
Start Date: 9-9-19
End Date: 9-23-19
"""
import math
import time

def coinFlip():
    N = 10000 #The norm
    A = 4857 #the Adder
    M = 8601 #The multiplier
    S = 0
    for i in range(25):
        S = (S*M + A) % N
        r = S/N
        
        coin = math.floor(2*r)
        if coin == 0:
            print('T')
        else:
            print('H')
            
def dieRoll():
    N = 10000 #The norm
    A = 4857 #the Adder
    M = 8601 #The multiplier
    S = 0
    for i in range(25):
        S = (S*M + A) % N
        r = S/N
    
        die = math.floor(6*r+1)
        print("Die number ",die)    

def ballToss():
    N = 10000 #The norm
    A = 4857 #the Adder
    M = 8601 #The multiplier
    Sum = 0 #Accumulator for simulation experiment
    S = 48484
    E = 595985 #The number of experiments
    for j in range(E):   
        Ball = [0,0,0]
        for i in range(3):
            S = (S*M + A) % N
            r = S/N
            can_number = math.floor(5*r+1)
            Ball[i] = can_number
            
        if (Ball[0] != Ball[1]) and (Ball[1] != Ball[2]) and (Ball[2] != Ball[0]):
            Sum = Sum + 1 #Incrementing for each favorable outcome 
            
    prob = Sum/E
    print("Ball toss probability ",prob)

def twodicerolling():
    N = 100000
    A = 4857
    M = 8601
    Rolls = []
    
    Z = 0
    while Z != 7:
        
        S1 = time.perf_counter_ns() % 999999
        S2 = time.perf_counter_ns() % 10000
        
        S1 = (S1 * M + A) % N
        S2 = (S2 * M + A) % N
        
        r1 = S1/N
        r2 = S2/N
        
        die1 = math.floor(6*r1 + 1)
        die2 = math.floor(6*r2 + 1)
    
        
        Z = die1 + die2
        Rolls.append(Z)
    return Rolls
    
def main():
    
    coinFlip()
    dieRoll()
    ballToss()
    
    three = 0
    fail = 0
    success = 0
    
    for i in range(100000):
        x = twodicerolling()
        
        try:
            three = x.index(3)
            a = three  + 1
            success = success + a
        except ValueError:
            b = len(x)
            fail = fail + b
        
    p = success / (success + fail)
    print("3 before 7 die roll probability ",p)
    
main()
    












