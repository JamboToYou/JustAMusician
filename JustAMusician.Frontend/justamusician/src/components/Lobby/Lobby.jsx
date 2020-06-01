import React from 'react';

import LobbyOrder from '../Order/LobbyOrder.jsx';

const mockData = [
	{
		title: "Ищу басиста",
		body: "Some quick example text to build on the card title and make up the bulk of the card's content."
	},
	{
		title: "Ищу носки",
		body: "Some quick example text to build on the card title and make up the bulk of the card's content."
	},
	{
		title: "Требуется музыка",
		body: "Some quick example text to build on the card title and make up the bulk of the card's content."
	},
	{
		title: "Требуется музыка",
		body: "Some quick example text to build on the card title and make up the bulk of the card's content."
	},
	{
		title: "Ищу басиста",
		body: "Some quick example text to build on the card title and make up the bulk of the card's content."
	},
	{
		title: "Ищу басиста",
		body: "Some quick example text to build on the card title and make up the bulk of the card's content."
	}
];

class Lobby extends React.Component {

	constructor(props) {
		super(props);
		this.state = {
			orders: []
		}
	}

	componentDidMount() {
		// fetch("/lobby-orders")
		// 	.then(response => response.json())
		// 	.then(data => this.setState({ orders: data }));
		this.setState({ orders: mockData });
	}

	render() {
		return (
			<div className="container-fluid row">
				<div className="col-md-3 col-lg-2" id="jam-sidebar-container">
					<div className="list-group">
						<a href="#" className="bg-warning list-group-item list-group-item-action active">Cras justo odioo</a>
						<a href="#" className="bg-warning list-group-item list-group-item-action">Dapibus ac facilisis in</a>
						<a href="#" className="bg-warning list-group-item list-group-item-action">Morbi leo risus</a>
						<a href="#" className="bg-warning list-group-item list-group-item-action">Porta ac consectetur ac</a>
						<a href="#" className="bg-warning list-group-item list-group-item-action disabled" tabindex="-1"
							aria-disabled="true">Vestibulum at eros</a>
					</div>
				</div>
				<div className="col-md-9 col-lg-10 jumbotron mr-0 w-100 bg-light p-4" id="jam-content-container">
					<div className="row mb-4">

						{this.state.orders.map(({title, body}) =>
							<LobbyOrder title={title} body={body} /> )}

					</div>
				</div>
			</div>
		);
	}

}

export default Lobby;