# CHILI_Dominos

This project implements a solution to a coding challenge: 
**Determine whether a circular domino chain can be created from a given set of domino tiles.
**If a circular chain is possible, the program generates and displays it. Otherwise, it informs the user that no such chain exists.

## Challenge Description

Given a random set of domino tiles, compute a way to order them such that they form a correct circular domino chain. In a valid chain:
- The dots on one half of a tile match the dots on the adjacent tile.
- The chain's first and last tiles must connect to form a circle.

## Features

- **GenerateTiles**: Generates a full set of domino tiles.
- **PickRandomTiles**: Picks a random set of tiles from a given list.
- **CanAChainBeMade**: Checks if a chain can be made with the chosen tiles.
- **TryCreateCircularChain**: Attempts to create a circular chain with the chosen tiles.
- **DisplayChain**: Displays the chain of tiles.

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later

### Installation

1. Clone the repository:
	git clone https://github.com/yourusername/dominoes-services.git
2. Navigate to the project directory:
    cd dominoes-services

### Usage

1. Build the project:
    dotnet build
2. Run the project:
    dotnet run
	
### Example

- Input: `[2|1], [2|3], [1|3]`
- Valid Outputs:
  - `[1|2], [2|3], [3|1]`
  - `[2|1], [1|3], [3|2]`

If a circular chain is impossible, the program outputs an appropriate message.

## Contributing

Contributions are welcome! Please open an issue or suggestion, or submit a pull request for any changes.

## Support

If you like this project, give it a ⭐ and let's have a chat about possible collaborations!
 
## Contact

For any questions or feedback, please contact me.
