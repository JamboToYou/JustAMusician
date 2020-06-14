import React from 'react';
import { search } from '../../utils/authRequests.js';

import LobbyOrder from '../Order/LobbyOrder.jsx';

class SearchResults extends React.Component {

	constructor(props) {
		super(props);
		this.state = {
			orders: []
		}
	}

	componentDidMount() {
		console.log(this.props.location.state);
		search(
			JSON.stringify(this.props.location.state),
			(data, textStatus, xhr) => {
				this.setState({ orders: data });
				console.log('=============');
				console.log(data);
				console.log('=============');
			},
			(xhr, errData, errThrown) => {}
		);
	}

	render() {
		return (
			<div>
				<p className="display-3">Результаты поиска</p>
				<div className="row mb-4">
					{this.state.orders.map((order) =>
						<LobbyOrder order={order}/> )}

				</div>
			</div>
		);
	}

}

export default SearchResults;
