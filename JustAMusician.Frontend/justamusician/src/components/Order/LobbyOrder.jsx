import React from 'react';

const LobbyOrder = ({ title, body }) => {
	return (
		<div className="col-12 col-sm-6 col-md-4 col-lg-3 p-2">
			<div className="card h-100">
				<div className="card-body">
					<p className="card-title jam-order-title">{ title }</p>
					<p className="card-text">{ body }</p>
				</div>
				<div className="row pr-4 pb-4">
					<a className="text-info offset-6" href="#">Имя пользователя</a>
				</div>
				<div className="card-footer d-flex justify-content-end">
					<a href="#" className="btn btn-primary">Перейти</a>
				</div>
			</div>
		</div>
	);
}

export default LobbyOrder;