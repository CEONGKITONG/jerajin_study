package org.zerock.exception;

import org.springframework.http.HttpStatus;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.servlet.NoHandlerFoundException;

import lombok.extern.log4j.Log4j;

//자동 생성 어노테이션 - @Coontroller, @Service, @Repository, @Component, @RestController, @ControllerAdvice
//@Coontroller - servlet-context.xml 에 선언, 그 외 어노테이션 - root-context.xml에 선언
@ControllerAdvice
@Log4j
public class CommonExceptionAdvice {
	
	// 500번 예외 전체 - Exception
	@ExceptionHandler(Exception.class)
	public String exception(Exception e, Model model) {
		
		log.error("Exception .......");
		model.addAttribute("exception", e);
		log.error(model);
		
		return "error/error_page";
	}
	
	
	// 404번 오류 처리
	@ExceptionHandler(NoHandlerFoundException.class)
	@ResponseStatus(HttpStatus.NOT_FOUND)
	public String handl404(NoHandlerFoundException e) {
		log.error("404 Error");
		return "error/custom404";
		
	}

}
