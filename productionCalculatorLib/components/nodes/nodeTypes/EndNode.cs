﻿using System.Collections.ObjectModel;
using productionCalculatorLib.components.nodes.enums;
using productionCalculatorLib.components.nodes.exceptions;
using productionCalculatorLib.components.nodes.interfaces;

namespace productionCalculatorLib.components.nodes.nodeTypes;

public class EndNode: INodeIn, IHasProduct
{
    public NodeTypes NodeType => NodeTypes.End;
    private readonly List<INode> _inputNodes = new();
    public Product Product { get; set; }
    public int Amount { get; set; }

    public EndNode(Product product, int amount)
    {
        Product = product;
        Amount = amount;
    }

    public IList<INode> InputNodes => new ReadOnlyCollection<INode>(_inputNodes);
    
    public void AddInputNode(INodeOut node)
    {
        if (_inputNodes.Count == 0)
        {
            _inputNodes.Add(node);
        }
        else
        {
            throw new MaxConnectionsReachedException("Only 1 input connection is allowed on end-node");
        }
    }
    
    public void RemoveConnectedNode(INode node)
    {
        _inputNodes.Remove(node);
    }
}