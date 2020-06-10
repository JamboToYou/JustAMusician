import React from 'react'
import { getUser } from '../../utils/authRequests.js';
import './profile-style.css';

class Profile extends React.Component {

	constructor(props) {
		super(props);
		this.state = {
			...props.user
		}
	}

	render() {
		return (
			<div className="container emp-profile">
				<form method="post">
					<div className="row mb-5">
						<div className="col-md-4">
						</div>
						<div className="col-md-6">
							<div className="profile-head">
								<h5>
									@{this.state.nickname}
								</h5>
								<h6>
									{this.state.email}
								</h6>
							</div>
						</div>
					</div>
					<div className="row">
						<div className="col-md-4">
							<div className="profile-work p-1">
								<p>Ссылки:</p>
								{this.state.links.length === 0
									? <p>Нет ссылок</p>
									: this.state.links.map(link =>
										<div><a className="text-danger" href={link}>{link}</a></div>
									)}
							</div>
						</div>
						<div className="col-md-8">
							<ul className="nav nav-tabs mb-4" id="myTab" role="tablist">
								<li className="nav-item">
									<a className="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab"
										aria-controls="home" aria-selected="true">О себе</a>
								</li>
								<li className="nav-item">
									<a className="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab"
										aria-controls="profile" aria-selected="false">Группы</a>
								</li>
							</ul>
							<div className="tab-content profile-tab p-2" id="myTabContent">
								<div className="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
									<div className="row">
										<div className="col-md-6">
											<label>UserId</label>
										</div>
										<div className="col-md-6">
											<p>{this.state.userId}</p>
										</div>
									</div>
									<div className="row">
										<div className="col-md-6">
											<label>Email</label>
										</div>
										<div className="col-md-6">
											<p>{this.state.email}</p>
										</div>
									</div>
									<div className="row">
										<div className="col-md-6">
											<label>Инструменты</label>
										</div>
										<div className="col-md-6">
											<p>{this.state.instruments.join(', ')}</p>
										</div>
									</div>
									<div className="row">
										<div className="col-md-6">
											<label>О себе</label>
										</div>
										<div className="col-md-6">
											<p>{this.state.about}</p>
										</div>
									</div>
								</div>
								<div className="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
									{this.state.bands.length === 0
										?<p>Не участвует в группах</p>
										:<div className="row">
											<div className="col-md-6">
												<label>Availability</label>
											</div>
											<div className="col-md-6">
												<p>6 months</p>
											</div>
										</div>}
								</div>
							</div>
						</div>
					</div>
				</form>
			</div>
		);
	}
}

export default Profile;