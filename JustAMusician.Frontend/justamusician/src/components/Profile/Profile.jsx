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
						<div className="col-md-2">
							<input type="submit" className="profile-edit-btn" name="btnAddMore" value="Edit Profile" />
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
			// <div className="jumbotron row bg-light m-4">
			// 	<div className="col-6 text-center">
			// 		<p className="display-3">@Sraphime</p>
			// 		<p className="display-5 text-secondary">Поствейв-рок</p>
			// 		<p className="display-5 text-secondary">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Architecto illum quos quas doloremque sapiente repellendus fuga explicabo sit in quo culpa, doloribus necessitatibus, natus facilis amet possimus veniam officia aliquid. Inventore deleniti nemo laboriosam dignissimos quo, facere totam pariatur sequi corporis blanditiis quia optio culpa! Accusantium a aliquid, unde ab, perferendis, blanditiis molestiae explicabo ipsum nulla, iusto aut quo dolore repudiandae veritatis laborum dolorem commodi ipsa itaque. Dolores maxime at molestiae, dolorem sit excepturi. Laboriosam deleniti atque veniam modi, omnis distinctio nostrum illum, voluptates dolorum mollitia minima maiores, laudantium tenetur eaque facilis perspiciatis minus vero harum quos possimus sunt ipsum!</p>
			// 		<div className="d-flex justify-content-center w-100">
			// 			<div className="jumbotron bg-info w-50 pt-1 pb-1">
			// 				<a className="row text-warning" href="#">seraph@jeerth.us</a>
			// 				<a className="row text-warning" href="#">facebook.com/556seraph__</a>
			// 				<a className="row text-warning" href="#">instagram.com/556seraph__</a>
			// 				<input type="file" onChange={this.testImage} />
			// 			</div>
			// 		</div>
			// 	</div>
			// 	<div className="col-6 justify-content-center">
			// 		<img className="image-thumbnail border rounded-circle" src="data:image/jpeg;base64,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"/>
			// 		<p className="display-4 text-info">seraph@jeerth.us</p>
			// 	</div>
			// </div>
		);
	}
}

export default Profile;