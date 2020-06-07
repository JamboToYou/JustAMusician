import $ from 'jquery';

const auth = (data, func) => postRequest("https://localhost:5001/api/auth/token")(data,
	(data, status, xhr) => {
		localStorage.setItem("auth", JSON.stringify(data));
		func(true);
	},
	(xhr, errorData, errorThrown) => func(false)
)

const register = (data, sucFunc, errFunc) =>
	postRequest("https://localhost:5001/api/auth/signup")(data, sucFunc, errFunc);

const authorized = (func) => {
	if (localStorage.getItem("auth")) {
		let token = JSON.parse(localStorage.getItem("auth")).access_token;
		$.ajax({
			url: "https://localhost:5001/api/user/get",
			method: "GET",
			headers: {
				"Accept": "application/json",
				"Access-Control-Allow-Origin": "*",
				"Authorization": "Bearer " + token
			},
			success: (data, status, xhr) => func(true),
			error: (xhr, errorData, errorThrown) => func(false)
		});
	} else {
		func(false);
	}
}

const postRequest = (url) => (data, sucFunc, errFunc) => {
	$.ajax({
		url,
		method: "POST",
		headers: {
			"Access-Control-Allow-Origin": "*",
			"Content-Type": "application/json; charset=utf-8"
		},
		data: data,
		success: (data, status, xhr) => sucFunc(data, status, xhr),
		error: (xhr, errorData, errorThrown) => errFunc(xhr, errorData, errorThrown)
	});
}

export { auth, register, authorized };