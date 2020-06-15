import React from 'react';
import { Link } from 'react-router-dom';
import { getOrder } from '../../utils/authRequests.js';
import moment from 'moment';
import 'moment/locale/ru';

moment.locale('ru');

class Order extends React.Component {

	constructor(props) {
		super(props);
		this.state = {
			orderId: "",
			title: "",
			body: "",
			createdAt: "",
			updatedAt: "",
			genres: [],
			instruments: [],
			email: "",
			nickname: "",
			ownerId: ""
		}
	}

	componentDidMount() {
		const { match: { params } } = this.props;
		getOrder(
			params.id,
			(data, status, xhr) => {
				console.log(data);
				this.setState({
					orderId: data.orderId,
					title: data.title,
					body: data.body,
					createdAt: data.createdAt,
					updatedAt: data.updatedAt,
					genres: data.genres,
					instruments: data.instruments,
					email: data.owner.email,
					nickname: data.owner.nickname,
					ownerId: data.ownerId
				});
			},
			(x, y, z) => {}
		);
	}

	render() {
		return(
			<div className="container">
				<p className="display-3">{this.state.title}</p>
				<p className="display-5 m-0">Создан</p>
				<p className="display-5 m-0">{moment(this.state.createdAt).fromNow()}</p>
				<p className="display-5 m-0">Обновлен</p>
				<p className="display-5 m-0">{moment(this.state.updatedAt).fromNow()}</p>

				<div className="row">
					<div className="col-6">
						<hr/>
						<p>{this.state.body}</p>
					</div>
					<div className="col-6">
						<Link to={"/otherProfile/" + this.state.ownerId } className="display-4 m-0">@{this.state.nickname}</Link>
						<p className="display-5 m-0">{this.state.email}</p>
					</div>
				</div>
				<hr/>
				<div className="row">
					<div className="col-6">
						<p>Жанры</p>
						<ul>
							{this.state.genres.map(genre => <li>{genre}</li>)}
						</ul>
					</div>
					<div className="col-6">
						<p>Инструменты</p>
						<ul>
							{this.state.instruments.map(instrument => <li>{instrument}</li>)}
						</ul>
					</div>
				</div>
			</div>
		);
	}

}

export default Order;