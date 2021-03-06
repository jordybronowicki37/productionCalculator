using productionCalculatorLib.components.nodes.enums;
using productionCalculatorLib.components.nodes.nodeTypes;

namespace SiteReact.Controllers.dto.nodes;

public class DtoNodeSpawn : NodeDto
{
    public DtoNodeSpawn(SpawnNode node)
    {
        Id = node.Id;
        Type = NodeTypes.Spawn.ToString();;
        
        Amount = node.Amount;
        Product = node.Product;
        
        OutputNodes = node.OutputConnections.Select(n => new DtoConnectionSingle(n.NodeOut.Id, n));
    }
}