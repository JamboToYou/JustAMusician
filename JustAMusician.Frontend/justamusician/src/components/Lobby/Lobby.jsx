import $ from 'jquery';
import React from 'react';
import { getOrders } from '../../utils/authRequests.js';

import LobbyOrder from '../Order/LobbyOrder.jsx';

class Lobby extends React.Component {

	constructor(props) {
		super(props);
		this.state = {
			orders: []
		}
	}

	componentDidMount() {
		getOrders(
			(data, textStatus, xhr) => {
				this.setState({ orders: data });
				console.log(data);
				console.log('------------');
			},
			(xhr, errData, errThrown) => {}
		);
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
