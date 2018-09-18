###############################################################
#  This program is for processing the output states from QUBA
#  in PTester
###############################################################
from __future__ import print_function
from collections import defaultdict
import re
import os
import sys
import argparse

import networkx as nx
import matplotlib.pyplot as plt

null=''

HASH='Hash'
IMPLMACHINE='ImplMachine'
SPECMACHINE='SpecMachines'
BASE='Base'

###############################################################
# parse output states from QUBA
# classes for defining objects
###############################################################
class Base(object):
    renamedName      = ''
    isSafe           = False
    instanceNumber   = 1
    fields           = null
    eventValue       = null
    stateStack       = ""
    invertedFunStack = list()
    continuation     = list()
    currentStatus    = ""
    nextSMOperation  = ""
    stateExitReason  = ""
    currentTrigger   = null
    currentPayload   = null
    destOfGoto       = null         

    # def __init__(self,
    #              renamedName,
    #              isSafe,
    #              instanceNumber,
    #              fields,
    #              eventValue,
    #              stateStack,
    #              invertedFunStack,
    #              continuation,
    #              currentStatus,
    #              nextSMOperation,
    #              stateExitReason,
    #              currentTrigger,
    #              currentPayload,
    #              destOfGoto):
    #     self.renamedName      = renamedName
    #     self.isSafe           = isSafe
    #     self.instanceNumber   = instanceNumber
    #     self.fields           = fields
    #     self.eventValue       = eventValue
    #     self.stateStack       = stateStack
    #     self.invertedFunStack = invertedFunStack
    #     self.continuation     = continuation
    #     self.currentStatus    = currentStatus
    #     self.nextSMOperation  = nextSMOperation
    #     self.stateExitReason  = stateExitReason
    #     self.currentTrigger   = currentTrigger
    #     self.currentPayload   = currentPayload
    #     self.destOfGoto       = destOfGoto
        
    def write(self):
        print("  Base:")

class Queue(object):
    events = list()

    # def __init__(self,
    #              events):
    #     self.events = list()
        
class ImplMachine(object):
    base  = Base()
    queue = Queue()

class SpecMachines():
    value = list()

class State(object):
    hash  = 0
    implMachines = list()
    specMachines = list()

###############################################################
# functions for parsing and comparing states
###############################################################
stateInString = list()
stateHashLine = list()
def readStatesFromFile(filename):
    lineno = 0
    with open(filename) as ins:
        for line in ins:            
            line = line.strip('\n')
            if line.startswith('='):
                continue
            if line.startswith(HASH):
                stateHashLine.append(lineno)
            stateInString.append(line)
            lineno += 1

def parseStates(states, indices):
    sz = len(indices)
    if sz == 0:
        raise ValueError
    start = indices[0]
    for i in range(sz - 1):
        end = indices[i+1]
        parseState(states[start:end])
        start = end
        print('==================================================')
    parseState(states[start:len(states)])
    print('==================================================')
    
def parseState(stateInStr):
    # print("\n".join(stateInStr))
    hash = 0
    m = re.search('(?<=Hash: )[-+]?[0-9]+$', stateInStr[0].strip())
    if m:
        hash = int(m.group(0))
        print(hash)
    for i in range(1,len(stateInStr)):
        line = stateInStr[i]
        if line.startswith(IMPLMACHINE):
            line = line.strip(':')
            print('{}: {}'.format(i, line))
            # m = re.search('(?<=ImplMachine )[0-9]+', line)              
                #         if m:
                #             machineID=int(m.group(0))
                #             print(machineID)
                #     line = ins.next()
        elif line.startswith(SPECMACHINE):
            m = re.search('(?<=SpecMachine ).*', line)
            if m:
                content = m.group(0)
                if content == '(none)':
                    print('(none)')
###############################################################
# draw relational graph
###############################################################
def drawRelationalGraph(filename):
    G = nx.DiGraph()
    with open(filename) as ins:
        line = ins.readline()
        start = int(line.strip())
        while line:
            line = line.strip()
            if line.find("->") == -1:
                line = ins.readline()
                continue
            nodes = line.split('->')
            # print("{}->{}".format(nodes[0], nodes[1]))
            n1 = int(nodes[0].strip())
            n2 = int(nodes[1].strip())
            G.add_edge(n1, n2)
            line = ins.readline()
        print(G.edges())

        pos = nx.spring_layout(G)
        # nx.draw(G,
        #         pos,
        #         # node_size=50,
        #         with_labels=True)

        tree = nx.bfs_tree(G, start)
        nx.draw(tree,
                pos,
                node_size=50,
                node_color='b',
                with_labels=False)
        for p in pos:  # raise text positions
            pos[p][1] += 0.03
        # nx.draw_networkx_nodes(G,
        #                        pos,
        #                        nodelist=[start],
        #                        node_color='r')
        nx.draw_networkx_labels(G,
                                pos,
                                font_size=7)
        plt.show()
        # plt.savefig("graph.png")
    
###############################################################
# main function
###############################################################
# command line parser
parser = argparse.ArgumentParser()
parser.add_argument('-c', '--compare', nargs = 2)
parser.add_argument("-g", "--graph",
                    help = 'draw a relational graph, nodes are hash values')

_args_ = parser.parse_args()

# main function
def main():
    if _args_.compare:
        newFile = _args_.compare[0]
        oldFile = _args_.compare[1]
        # print("{}.{}".format(newFile, oldFile))

        readStatesFromFile(newFile)
        parseStates(stateInString, stateHashLine)
        # oldStates = parseStatesFromFile(oldFile)
    if _args_.graph:
        drawRelationalGraph(_args_.graph)
        
if __name__ == "__main__":
    main()
