# -*- coding: utf-8 -*-
"""
EE 381 Fall 2019
Project 3
Name: Dennis Maya
I.D.#: 015850768
Start Date: 9-23-19
End Date:
This project is about Markov chains
and uses Bernoulli R.V.s.
"""

import random
#Simulation of a bernoulli R.V.
print('Simulation of a Bernoulli random variable.')
p = float(input('Enter the probability of a success. '))
T = int(input('Enter the number of trials you want to run. '))
print('\n')

for j in range(T):
    r = random.uniform(0,1)
    if r < p:
        print('1',end=' ')
    else:
        pass
