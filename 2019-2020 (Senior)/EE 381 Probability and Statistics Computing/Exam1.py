# -*- coding: utf-8 -*-
"""
EE 381 Fall 2019
Exam 1
Name: Dennis Maya
I.D.#: 015850768
Date: 10-16-19
"""

import random
import math

trials = int(input('Enter the number of trials you want to run. '))
print("\n")

probs = []
probs.append(0)
probs.append(0)
probs.append(0)
turns = []
turns.append(0)
turns.append(0)
turns.append(0)
for j in range(trials):
    turn = 1
    coin = -1
    prob = 1/2
    while(coin != 1):
        r = random.uniform(0,2)
        coin = int(math.floor(r))
        if coin == 0:
            prob *= 1/2
        elif(coin == 1):
            if turn == 1:
                #print("A won with a probability of: ", prob)
                probs[0] += prob
                turns[0] += 1
            elif turn == 2:
                #print("B won with a probability of: ", prob)
                probs[1] += prob 
                turns[1] += 1
            elif turn == 3:
                #print("C won with a probability of: ", prob)
                probs[2] += prob 
                turns[2] += 1
        if turn == 3:
            turn = 1
        else:
            turn += 1
    
print("Probability of A: ", probs[0] /turns[0])
print("Probability of B: ", probs[1]/turns[1])
print("Probability of C: ", probs[2]/turns[2])