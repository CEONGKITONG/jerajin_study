package org.zerock.notice.vo;

import java.util.Date;

import org.springframework.format.annotation.DateTimeFormat;

import lombok.Data;

@Data
public class NoticeVO {
	
	private long no;
	private String title, content;
	// 받는 데이터는 String으로 들어와서 오류가 난다. -> @DateTimeFormat
	@DateTimeFormat(pattern = "yyyy-MM-dd")	// SimpleDateFormat class 패턴 규칙 준수
	private Date startDate, endDate;
	private Date writeDate, updateDate;

}
