package org.zerock.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import lombok.extern.log4j.Log4j;

// uri - /sample/*
//	mapping은 class 위에, 메서드 위에 맵핑 시킬 수 있다.
//		class 위에 - uri 앞에단
//		메서드 위에 - 클래스 맵핑 + 메서드 맵핑 => 전체 uri에 해당이 된다.
@Controller
@RequestMapping("/sample/*")
@Log4j
public class SampleController {
	
	// String - redirect: 이 안붙으면 jsp로 forward 된다, redirect: 이 붙어 있으면 페이지 이동
	//	void - uri 가 jsp의 정보가 된다. 예) /sample/test -> /sample/test.jsp 를 자동 찾는다.
	@RequestMapping("/basic")
//	@RequestMapping("")   http://localhost/sample/basic 로 입력하면 http://localhost/sample/basic.jsp 로 맵핑해서 가져온다.
	public void basic() {
		log.info("basic..............................");
	}
	
	// url -> /sample/basic
	@RequestMapping(value="/basicGet", method = RequestMethod.GET)	// uri -> /sample/basic
	public void basicGet() {
		log.info("basicGet()..............................");
	}

	@GetMapping("/basicGet2")	
	public void basicGet2() {
		log.info("basicGet2()..............................");
	}

}
