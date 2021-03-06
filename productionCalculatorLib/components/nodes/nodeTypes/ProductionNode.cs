using System.Collections.ObjectModel;
using productionCalculatorLib.components.calculator.limitors;
using productionCalculatorLib.components.connections;
using productionCalculatorLib.components.nodes.interfaces;
using productionCalculatorLib.components.products;

namespace productionCalculatorLib.components.nodes.nodeTypes;

public class ProductionNode: INodeInOut, IHasRecipe
{
    public int Id { get; }
    public Recipe Recipe { get; set; }
    public float ProductionAmount { get; set; } = 0;
    
    public ProductionNode(int id, Recipe recipe)
    {
        Id = id;
        Recipe = recipe;
    }

    private readonly List<Connection> _inputConnections = new();
    private readonly List<Connection> _outputConnections = new();
    public IList<Connection> InputConnections => new ReadOnlyCollection<Connection>(_inputConnections);
    public IList<Connection> OutputConnections => new ReadOnlyCollection<Connection>(_outputConnections);
    public void AddInputConnection(Connection connection)
    {
        if (!_inputConnections.Contains(connection))_inputConnections.Add(connection);
    }
    public void AddOutputConnection(Connection connection)
    {
        if (!_outputConnections.Contains(connection))_outputConnections.Add(connection);
    }
    public void RemoveConnnection(Connection connection)
    {
        _inputConnections.Remove(connection);
        _outputConnections.Remove(connection);
    }

    public List<LimitProduction> ProductionLimits { get; }
    public void AddProductionLimit(LimitProduction limit)
    {
        if (!ProductionLimits.Contains(limit)) ProductionLimits.Add(limit);
    }
    public void RemoveProductionLimit(LimitProduction limit)
    {
        ProductionLimits.Remove(limit);
    }
}