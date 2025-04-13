/**
 * @license Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For the complete reference:
	// http://docs.ckeditor.com/#!/api/CKEDITOR.config

	// The toolbar groups arrangement, optimized for two toolbar rows.
	//config.toolbarGroups = [
	//	{ name: 'clipboard',   groups: [ 'clipboard', 'undo' ] },
	//	{ name: 'editing',     groups: [ 'find', 'selection', 'spellchecker' ] },
	//	{ name: 'links' },
	//	{ name: 'insert' },
	//	{ name: 'forms' },
	//	{ name: 'tools' },
	//	{ name: 'document',	   groups: [ 'mode', 'document', 'doctools' ] },
	//	{ name: 'others' },
	//	'/',
	//	{ name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ] },
	//	{ name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align' ] },
	//	{ name: 'styles' },
	//	{ name: 'colors' },
	//	{ name: 'about' }
	//];

	//// Remove some buttons, provided by the standard plugins, which we don't
	//// need to have in the Standard(s) toolbar.
 

	config.filebrowserImageBrowseUrl = CKEDITOR.basePath + "../ui/admin/browsers/ImageBrowser.aspx";
	config.filebrowserWindowFeatures = 'location=no,menubar=no,toolbar=no,dependent=yes,minimizable=no,modal=yes,alwaysRaised=yes,resizable=yes,scrollbars=yes';
	config.filebrowserImageWindowWidth = 780;
	config.filebrowserImageWindowHeight = 720;
	config.filebrowserBrowseUrl = CKEDITOR.basePath + "../ui/admin/browsers/LinkBrowser.aspx";
	config.filebrowserWindowWidth = 500;
	config.filebrowserWindowHeight = 650;
};
