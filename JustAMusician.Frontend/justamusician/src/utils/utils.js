function isNullOrWhitespace(input) {
	return !input || !input.trim();
}

function normalizeNodes(nodes) {
	return nodes.map(node => {
		if (node.children.length == 0)
			return { value: node.value, label: node.label };
		return { value: node.value, label: node.label, children: normalizeNodes(node.children) };
	})
}

function isUrl(str) {
	var pattern = new RegExp('^(https?:\\/\\/)?'+ // protocol
		'((([a-z\\d]([a-z\\d-]*[a-z\\d])*)\\.)+[a-z]{2,}|'+ // domain name
		'((\\d{1,3}\\.){3}\\d{1,3}))'+ // OR ip (v4) address
		'(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*'+ // port and path
		'(\\?[;&a-z\\d%_.~+=-]*)?'+ // query string
		'(\\#[-a-z\\d_]*)?$','i'); // fragment locator
	return !!pattern.test(str);
}

export { isNullOrWhitespace, normalizeNodes, isUrl };