import React from 'react';
import $ from 'jquery';
import { Redirect } from 'react-router-dom';
import CheckboxTree from 'react-checkbox-tree';
import { addOrder } from '../../utils/authRequests.js';
import { isNullOrWhitespace, isUrl } from '../../utils/utils.js';

const genreIcons = {
	check: <span className="rct-icon rct-icon-check" />,
	uncheck: <span className="rct-icon rct-icon-uncheck" />,
	halfCheck: <span className="rct-icon rct-icon-half-check" />,
	expandClose: <span className="rct-icon rct-icon-expand-close" />,
	expandOpen: <span className="rct-icon rct-icon-expand-open" />,
	expandAll: <span className="rct-icon rct-icon-expand-all" />,
	collapseAll: <span className="rct-icon rct-icon-collapse-all" />,
	parentClose: <span className="fas fa-music" />,
	parentOpen: <span className="fal fa-music" />,
	leaf: <span className="fas fa-music" />,
};

const instrumentIcons = {
	check: <span className="rct-icon rct-icon-check" />,
	uncheck: <span className="rct-icon rct-icon-uncheck" />,
	halfCheck: <span className="rct-icon rct-icon-half-check" />,
	expandClose: <span className="rct-icon rct-icon-expand-close" />,
	expandOpen: <span className="rct-icon rct-icon-expand-open" />,
	expandAll: <span className="rct-icon rct-icon-expand-all" />,
	collapseAll: <span className="rct-icon rct-icon-collapse-all" />,
	parentClose: <span className="fas fa-guitar" />,
	parentOpen: <span className="fal fa-guitar" />,
	leaf: <span className="fas fa-guitar" />,
};

class EditProfile extends React.Component {

	constructor(props) {
		super(props);
		this.submitForm = this.submitForm.bind(this);
		this.addLink = this.addLink.bind(this);
		this.removeLink = this.removeLink.bind(this);
		this.handleLinkInput = this.handleLinkInput.bind(this);
		this.handleAboutInput = this.handleAboutInput.bind(this);
		this.state = {
			linkValid: 0,
			allGenres: props.genres,
			allInstruments: props.instruments,

			genresExpanded: [],
			instrumentsExpanded: [],
			...props.user
		}
	}

	submitForm(event) {

	}

	handleLinkInput (event) {
		const val = event.target.value;
		if (isNullOrWhitespace(val))
			this.setState({ linkValid: 0 })
		else if(isUrl(val))
			this.setState({ linkValid: 1 })
		else
			this.setState({ linkValid: -1 })
	}

	addLink (event) {
		this.setState({
			links: [ ...this.state.links, $('#jam-add-link').val() ]
		});
		$('#jam-add-link').val('');
	}

	handleAboutInput (event) {
		this.setState({ about: event.target.value });
	}

	removeLink (link) {
		let idx = this.state.links.indexOf(link);
		let links = this.state.links;
		links.splice(idx, 1);
		this.setState({ links });
	}

	render() {
		let lnkValid = this.state.linkValid === 1 ? "is-valid" : (this.state.linkValid === -1 ? "is-invalid" : "");

		return (
			<div className="container" onSubmit={this.submitForm}>
				<p className="display-4">Редактирование профиля</p>
				<div className="row">
					<div className="col-12 col-lg-6 mb-2">
						<ul>
							{this.state.links.map((item, idx) =>
								<li className="row" key={idx}>
									<p className="col-8">{item}</p>
									<button
										className="btn btn-danger btn-sm col-1 offset-2"
										onClick={() => this.removeLink(item)}>
										<i className="fa fa-trash"></i>
									</button>
								</li>
							)}
						</ul>

						<div className="form-group">
							<input id="jam-add-link"
									name="link"
									type="url"
									className={"form-control " + lnkValid}
									placeholder="Введите ссылку"
									onChange={this.handleLinkInput} />
							<br/>
							<button
								className="btn btn-primary"
								disabled={this.state.linkValid !== 1}
								onClick={this.addLink}>Добавить ссылку</button>
						</div>
					</div>
					<div className="col-12 col-lg-6 mb-2">
						<div className="card jam-search-tree">
							<CheckboxTree
								nodes={this.state.allInstruments}
								checked={this.state.instruments}
								checkModel={"all"}
								onlyLeafCheckboxes
								expanded={this.state.instrumentsExpanded}
								onCheck={checked => this.setState({ instruments: checked })}
								onExpand={expanded => this.setState({ instrumentsExpanded: expanded })}
								iconsClass={"fa5"}
								icons={instrumentIcons}
							/>
						</div>
					</div>
				</div>
				<div className="row">
					<div className="form-group col-6">
						<label htmlFor="jam-profile-edit-about">О себе</label>
						<textarea
							className="form-control"
							name="body"
							onChange={this.handleAboutInput}
							id="jam-profile-edit-about"
							value={this.state.about}></textarea>
					</div>
				</div>
			</div>
		);
	}

}

export default EditProfile;