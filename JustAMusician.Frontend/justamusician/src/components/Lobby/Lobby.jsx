import React from 'react';

import LobbyOrder from '../Order/LobbyOrder.jsx';

class Lobby extends React.Component {

	constructor(props) {
		super(props);
		this.state = {
			orders: []
		}
	}

	componentDidMount() {
		// fetch('https://localhost:5001/api/order', {
		// 			method: 'GET',
		// 			mode: 'cors',
		// 			headers: { 'Access-Control-Allow-Origin': '*' }
		// 		})
		//  	.then(response => response.json())
		//  	.then(data => this.setState({ orders: data }));

		this.setState({ orders: this.props.orders });
	}

	render() {
		return (
			<div className="container-fluid row">
				<div className="col-md-3 col-lg-2" id="jam-sidebar-container">
					<div className="list-group">
						<a href="#" className="bg-warning list-group-item list-group-item-action disabled">Бенд-треды</a>
						<a href="#" className="bg-warning list-group-item list-group-item-action">Группы</a>
						<a href="#" className="bg-warning list-group-item list-group-item-action">Сессии</a>
						<a href="#" className="bg-warning list-group-item list-group-item-action">Концерты</a>
						<a href="#" className="bg-warning list-group-item list-group-item-action">Разработка материала</a>
					</div>
				</div>
				<div className="col-md-9 col-lg-10 jumbotron mr-0 w-100 bg-light p-4" id="jam-content-container">
					{this.props.children}
					<div className="row mb-4">
						{this.state.orders.map(({title, body, username}) =>
							<LobbyOrder title={title} body={body} username={username}/> )}

					</div>
				</div>
			</div>
		);
	}

}

export default Lobby;
