import React from 'react';
import { Redirect, Link } from 'react-router-dom';
import './register-style.css';
import { register } from '../../utils/authRequests.js';
import { isNullOrWhitespace } from '../../utils/utils.js';

class RegisterWindow extends React.Component {

	constructor(props) {
		super(props);

		this.submitHandler = this.submitHandler.bind(this);
		this.inputHandler = this.inputHandler.bind(this);
		this.validateField = this.validateField.bind(this);
		this.validateForm = this.validateForm.bind(this);

		this.state = {
			isEmailValid: 0,
			isNicknameValid: 0,
			isPasswordValid: 0,
			isPasswordConfirmationValid: 0,

			signedUp: false,
			valid: false,
			errorOccured: false,

			formErrors: {
				email: "",
				nickname: "",
				password: "",
				passwordConfirmation: ""
			},

			email: "",
			nickname: "",
			password: "",
			passwordConfirmation: ""
		}
	}

	submitHandler (event) {
		event.preventDefault();
		if (this.state.valid) {
			register(
				JSON.stringify({
					Email: this.state.email,
					Nickname: this.state.nickname,
					Password: this.state.password,
					PasswordConfirmation: this.state.passwordConfirmation,
					About: "",
					Links: [ "https://vk.com" ]
				}),
				(data, status, xhr) => {
					this.setState({ signedUp: true });
				},
				(xhr, errorData, errorThrown) => {
					// console.log(xhr);
					// console.log(errorData);
					// console.log(errorThrown);
					this.setState({
						signedUp: false,
						errorOccured: true
					});
				}
			);
		}
	}

	inputHandler (e) {
		const name = e.target.name;
		const value = e.target.value;
		this.setState({[name]: value}, 
			() => { this.validateField(name, value) });
	}

	validateField(fieldName, value) {
		let emailValid = this.state.isEmailValid;
		let nicknameValid = this.state.isNicknameValid;
		let passwordValid = this.state.isPasswordValid;
		let passwordConfirmationValid = this.state.isPasswordConfirmationValid;

		switch(fieldName) {
			case 'email':
				if (isNullOrWhitespace(value))
					emailValid = 0;
				else
					emailValid = value.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i) ? 1 : -1;
				break;
			case 'nickname':
				nicknameValid = isNullOrWhitespace(value) ? -1 : 1;
				break;
			case 'password':
				if (isNullOrWhitespace(value))
					passwordValid = 0;
				else
					passwordValid = value.length >= 8 ? 1 : -1;

				if (isNullOrWhitespace(this.state.passwordConfirmation))
					passwordConfirmationValid = 0;
				else
					passwordConfirmationValid =
						(value === this.state.passwordConfirmation && this.state.passwordConfirmation.length >= 8) ? 1 : -1;
				break;

				break;
			case 'passwordConfirmation':
				if (isNullOrWhitespace(value))
					passwordConfirmationValid = 0;
				else
					passwordConfirmationValid =
						(value === this.state.password && value.length >= 8) ? 1 : -1;
				break;
			default:
				break;
		}

		this.setState(
			{
				isEmailValid: emailValid,
				isNicknameValid: nicknameValid,
				isPasswordValid: passwordValid,
				isPasswordConfirmationValid: passwordConfirmationValid
			}, this.validateForm);
	}

	validateForm() {
		this.setState(
			{
				valid: this.state.isEmailValid === 1 &&
						this.state.isNicknameValid === 1 &&
						this.state.isPasswordValid === 1 &&
						this.state.isPasswordConfirmationValid === 1
			});
	}

	render() {
		if (this.state.signedUp) return <Redirect to="/" />;

		let emailDanger = this.state.isEmailValid === 0 ? "" : (this.state.isEmailValid === 1 ? "is-valid" : "is-invalid");
		let nicknamelDanger = this.state.isNicknameValid === 0 ? "" : (this.state.isNicknameValid === 1 ? "is-valid" : "is-invalid");
		let passwordDanger = this.state.isPasswordValid === 0 ? "" : (this.state.isPasswordValid === 1 ? "is-valid" : "is-invalid");
		let passwordConfirmationDanger = this.state.isPasswordConfirmationValid === 0 ? "" : (this.state.isPasswordConfirmationValid === 1 ? "is-valid" : "is-invalid");

		return (
			<form className="card mt-5 w-100" onSubmit={this.submitHandler}>

				<div className="card-header text-center">
					<p className="display-3 mb-0 text-info">JustAMusician</p>
				</div>

				<div className="card-body">
					<div className="text-center">
						<p id="jam-register-title">Регистрация</p>
					</div>
					{this.state.errorOccured
						? <div className="alert alert-danger" role="alert">Не удалось зарегистрироваться</div>
						: ""}
					<div className="form-group">
						<label htmlFor="jam-register-email">Адрес электронной почты:</label>
						<input id="jam-register-email"
								name="email"
								type="email"
								className={"form-control " + emailDanger}
								aria-describedby="jam-register-email-help"
								placeholder="Введите email"
								onChange={this.inputHandler} />
					</div>

					<div className="form-group">
						<label htmlFor="jam-register-nickname">Никнейм:</label>
						<input id="jam-register-nickname"
								name="nickname"
								type="text"
								className={"form-control " + nicknamelDanger}
								aria-describedby="jam-register-nickname-help"
								placeholder="Придумайте себе никнейм"
								onChange={this.inputHandler} />
					</div>

					<div className="form-group">
						<label htmlFor="jam-register-password">Пароль:</label>
						<input id="jam-register-password"
								name="password"
								type="password"
								className={"form-control " + passwordDanger}
								aria-describedby="jam-register-password-help"
								placeholder="Придумайте пароль"
								onChange={this.inputHandler} />
						<small id="jam-register-email-help" className="form-text text-info">
							Длина пароля должна быть не меньше 8 символов
						</small>
					</div>

					<div className="form-group">
						<label htmlFor="jam-register-password-confirm">Подтверждение пароля:</label>
						<input id="jam-register-password-confirm"
								name="passwordConfirmation"
								type="password"
								className={"form-control " + passwordConfirmationDanger}
								aria-describedby="jam-register-password-confirm-help"
								placeholder="Введите пароль повторно"
								onChange={this.inputHandler} />
					</div>

					<button type="submit" className="btn btn-primary btn-block" disabled={!this.state.valid}>Зарегистрироваться</button>
					<p className="forgot-password text-right">Уже есть профиль? <Link to="/">Войдите</Link></p>
				</div>
			</form>
		);
	}

}

export default RegisterWindow;