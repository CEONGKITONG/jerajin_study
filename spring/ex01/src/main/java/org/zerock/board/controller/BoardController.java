package org.zerock.board.controller;

import java.util.Arrays;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.zerock.board.service.BoardServiceImpl;
import org.zerock.board.vo.BoardVO;

import lombok.extern.log4j.Log4j;

//자동 생성 어노테이션 - @Coontroller, @Service, @Repository, @Component, @RestController, @Advice
//@Coontroller - servlet-context.xml 에 선언, 그 외 어노테이션 - root-context.xml에 선언

@Controller
@RequestMapping("/board")
@Log4j
public class BoardController {
	
	@Autowired
	private BoardServiceImpl	service;
	
	@RequestMapping("/list.do")
	public String list(Model model) {
		log.info("게시판 리스트................................");
//		System.out.println(10/0);
		model.addAttribute("list", service.list());
		return "board/list";
	}
	
	@RequestMapping("/view.do")
	public String view(long no, int inc, Model model) {
		log.info("게시판 글보기................................");
		log.info("no=" + no + ", inc=" + inc);
		model.addAttribute("vo", service.view(no, inc));
		return "board/view";
	}


	@GetMapping("/write.do")
	public String writeForm() {
		log.info("게시판 글쓰기 폼................................");
		return "board/write";
	}

	

	@PostMapping("/write.do")	
	public String write(BoardVO vo) {
		log.info("게시판 글쓰기 처리................................");
		log.info(vo);
		service.write(vo);
		return "redirect:list.do";
	}

	
	@GetMapping("/update.do")
	public String updateForm(long no, Model model) {
		log.info("게시판 수정 폼................................");
		model.addAttribute("vo", service.view(no, 0));
		return "board/update";
	}

	
	@PostMapping("/update.do")
	public String update(BoardVO vo) {
		log.info("게시판 글수정 처리................................");
		service.update(vo);
		return "redirect:view.do?no=" + vo.getNo() + "&inc=1";
	}

	
	@PostMapping("/delete.do")
	// @RequestParam(name, defaultValue, required, value) - 넘어오는 데이터의 ㅇ이름이 변수와 다른 경우, 값이 넘어오지 않는 경우 기본값, 필수항목, 값 세팅
	// 여러개의 데이터를 List 로 받으면 Class 를 사용해야한다.
//	public String delete(@RequestParam("no") List<Long> no) {
//	public String delete(long[] no) {
	public String delete(BoardVO vo) {
		log.info("게시판 글 삭제 처리................................");
//		log.info(Arrays.toString(no));
//		log.info(no);
		log.info(vo);
		service.delete(vo);
		return "redirect:list.do";
	}
	

}
