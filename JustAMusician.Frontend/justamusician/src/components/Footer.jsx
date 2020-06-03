import React from 'react';

const Footer = () => {
	return (
		<footer>
			<div className="container-fluid text-info">
				<div className="row">

					<div className="col-lg-4 col-md-6 pt-4">
						<h3>Map</h3>
						<ul className="list-unstyled three-column">
							<li>Домашняя</li>
							<li>Заявки</li>
							<li>О нас</li>
							<li>Поиск</li>
							<li>Связь</li>
						</ul>
						<ul className="list-unstyled socila-list">
							<li><img className="jam-footer-icon-sm" src="http://placehold.it/48x48" alt="" /></li>
							<li><img className="jam-footer-icon-sm" src="http://placehold.it/48x48" alt="" /></li>
							<li><img className="jam-footer-icon-sm" src="http://placehold.it/48x48" alt="" /></li>
							<li><img className="jam-footer-icon-sm" src="http://placehold.it/48x48" alt="" /></li>
							<li><img className="jam-footer-icon-sm" src="http://placehold.it/48x48" alt="" /></li>
							<li><img className="jam-footer-icon-sm" src="http://placehold.it/48x48" alt="" /></li>
						</ul>
					</div>

					<div className="col-lg-4 col-md-6">
						<h3>last Articles</h3>
						<div className="media">
							<a href="#" className="pull-left mr-3">
								<img src="http://placehold.it/64x64" alt="" className="media-object" />
							</a>
							<div className="media-body">
								<h4 className="media-heading">Группы</h4>
								<p>Новые воссоединения распавшихся групп.</p>
							</div>
						</div>

						<div className="media">
							<a href="#" className="pull-left mr-3">
								<img src="http://placehold.it/64x64" alt="" className="media-object" />
							</a>
							<div className="media-body">
								<h4 className="media-heading">Концерты</h4>
								<p>Тур по России.</p>
							</div>
						</div>

					</div>

					<div className="col-lg-4">
						<h3>Наши работы</h3>
						<img className="img-thumbnail" src="http://placehold.it/150x100" alt="" />
						<img className="img-thumbnail" src="http://placehold.it/150x100" alt="" />
					</div>

				</div>
			</div>
			<div className="copyright text-center text-light">
				jambotoyou 2017 <span>justamusician</span>
			</div>
		</footer>
	);
}

export default Footer;