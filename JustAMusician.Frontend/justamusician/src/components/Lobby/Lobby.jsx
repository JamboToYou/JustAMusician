import $ from 'jquery';
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
		$.ajax({
			method: 'GET',
			url: 'https://localhost:5001/api/order',
			headers: { "Access-Control-Allow-Headers": "*" },
			success: (data, textStatus, xhr) => {
				this.setState({ orders: data });
				console.log(data);
				console.log('------------');
			}
		});
		// this.setState({ orders: this.props.orders });
	}

	render() {
		return (
			<div>
				{this.props.children}
				<div className="row mb-4">
					{this.state.orders.map(({title, body, username}) =>
						<LobbyOrder title={title} body={body} username={username}/> )}

				</div>
			</div>
		);
	}

}

export default Lobby;
