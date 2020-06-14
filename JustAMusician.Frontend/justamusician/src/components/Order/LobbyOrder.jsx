import React from 'react';
import { Link } from 'react-router-dom';
import moment from 'moment';
import 'moment/locale/ru';

moment.locale('ru');

const LobbyOrder = ({order}) => {
	return (
		<div className="col-12 col-md-6 p-2">
			<div className="card h-100">
				<ul className="nav nav-tabs card-header" id={"jam-lobby-order-" + order.orderId} role="tablist">
					<li className="nav-item">
						<a className="nav-link active"
							id={"jam-lobby-order-tab-main-" + order.orderId}
							data-toggle="tab"
							href={"#jam-lobby-order-tab-pane-main-" + order.orderId}
							role="tab"
							aria-controls={"jam-lobby-order-tab-pane-main-" + order.orderId}
							aria-selected="true">Описание</a>
					</li>
					<li className="nav-item">
						<a className="nav-link" id={"jam-lobby-order-tab-about-" + order.orderId}
							data-toggle="tab" href={"#jam-lobby-order-tab-pane-about-" + order.orderId} role="tab"
							aria-controls={"jam-lobby-order-tab-pane-about-" + order.orderId}
							aria-selected="false">Инфо</a>
					</li>
				</ul>
				<div className="card-body tab-content">
					<div className="tab-pane fade show active"
						id={"jam-lobby-order-tab-pane-main-" + order.orderId}
						role="tabpanel"
						aria-labelledby={"jam-lobby-order-tab-main-" + order.orderId}>

						<p className="card-title jam-order-title">{ order.title }</p>
						<p className="card-text">{ order.body }</p>
					</div>
					<div className="tab-pane fade"
						id={"jam-lobby-order-tab-pane-about-" + order.orderId}
						role="tabpanel"
						aria-labelledby={"jam-lobby-order-tab-about-" + order.orderId}>
						<div className="row pr-4">
							<div className="col-6">
								<p className="text-muted mb-0">Создан</p>
								<p className="text-muted">{ moment(order.createdAt).fromNow() }</p>
								<p className="text-muted mb-0">Обновлен</p>
								<p className="text-muted">{ moment(order.updatedAt).fromNow() }</p>
							</div>
							<div className="col-6 d-flex justify-content-end">
								<Link className="text-info align-self-end" to={"/otherProfile/" + order.ownerId}>@{ order.ownerNickname }</Link>
							</div>
						</div>
					</div>
				</div>
				<div className="card-footer d-flex justify-content-end">
					<Link to={"/order/" + order.orderId} className="btn btn-primary">Перейти</Link>
				</div>
			</div>
		</div>
	);
}

export default LobbyOrder;